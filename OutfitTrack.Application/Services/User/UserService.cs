using OutfitTrack.Application.Interfaces;
using OutfitTrack.Application.Security;
using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces;

namespace OutfitTrack.Application.Services;

public class UserService(IUnitOfWork unitOfWork) : BaseService<IUserRepository, InputCreateUser, InputUpdateUser, User, OutputUser, InputIdentifierUser>(unitOfWork), IUserService
{
    public override OutputUser Create(InputCreateUser inputCreate)
    {
        User? originalUser = _repository!.GetByIdentifier(new InputIdentifierUser(inputCreate.Email));

        if (originalUser is not null)
            throw new InvalidOperationException($"E-mail '{inputCreate.Email}' já cadastrado.");

        User user = FromInputCreateToEntity(inputCreate);
        user.SetProperty(nameof(User.TokenExpirationDate), DateTime.UtcNow.AddDays(7));
        user.SetProperty(nameof(User.Password), PasswordEncryption.Encrypt(user.Password!));

        var entity = _repository.Create(user) ?? throw new InvalidOperationException("Falha ao criar o usuário.");
        _unitOfWork!.Commit();

        return FromEntityToOutput(entity);
    }

    public override OutputUser Update(long id, InputUpdateUser inputUpdate)
    {
        User? originalUser = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException($"Não foi encontrado nenhum usuário correspondente a este Id.");

        if (PasswordEncryption.Verify(inputUpdate.Password!, originalUser.Password!))
        {
            originalUser.SetProperty(nameof(User.Email), inputUpdate.Email);
            var entity = _repository!.Update(originalUser) ?? throw new InvalidOperationException("Falha ao atualizar o usuário.");
            _unitOfWork!.Commit();

            return FromEntityToOutput(entity);
        }

        throw new InvalidOperationException($"Senha incorreta.");
    }

    public bool RedefinePassword(long id, InputRedefinePasswordUser inputRedefinePassword)
    {
        User? originalUser = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException($"Não foi encontrado nenhum usuário correspondente a este Id.");

        if (PasswordEncryption.Verify(inputRedefinePassword.Password!, originalUser.Password!))
        {
            originalUser.SetProperty(nameof(User.Password), PasswordEncryption.Encrypt(inputRedefinePassword.NewPassword!));
            _repository!.Update(originalUser);
            _unitOfWork!.Commit();
            return true;
        }

        throw new InvalidOperationException($"Senha antiga incorreta.");
    }

    public void UpdateTokenExpirationDate(long id)
    {
        User? user = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException($"Não foi encontrado nenhum usuário correspondente a este Id.");
        user.SetProperty(nameof(User.TokenExpirationDate), DateTime.UtcNow.AddDays(7));
        _repository!.Update(user);
        _unitOfWork!.Commit();
    }
}