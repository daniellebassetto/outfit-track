using OutfitTrack.Application.Interfaces;
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
        var entity = _repository.Create(user) ?? throw new InvalidOperationException("Falha ao criar o usuário.");
        _unitOfWork!.Commit();

        return FromEntityToOutput(entity);
    }

    public override OutputUser Update(long id, InputUpdateUser inputUpdate)
    {
        User? originalUser = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException($"Não foi encontrado nenhum usuário correspondente a este Id.");

        User user = UpdateEntity(originalUser, inputUpdate) ?? throw new Exception("Problemas para realizar atualização.");
        user.SetProperty(nameof(User.TokenExpirationDate), DateTime.UtcNow.AddDays(7));

        var entity = _repository!.Update(user) ?? throw new InvalidOperationException("Falha ao atualizar o usuário.");
        _unitOfWork!.Commit();

        return FromEntityToOutput(entity);
    }
}