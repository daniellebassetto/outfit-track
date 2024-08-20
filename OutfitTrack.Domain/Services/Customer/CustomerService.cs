using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces.Repository;
using OutfitTrack.Domain.Interfaces.Service;

namespace OutfitTrack.Domain.Services;

public class CustomerService(IUnitOfWork unitOfWork) : BaseService<ICustomerRepository, InputCreateCustomer, InputUpdateCustomer, Customer, OutputCustomer, InputIdentifierCustomer>(unitOfWork), ICustomerService
{
    public override OutputCustomer? Create(InputCreateCustomer inputCreate)
    {
        Customer? originalCustomer = _repository!.GetByIdentifier(new InputIdentifierCustomer(inputCreate.Cpf));

        if (originalCustomer is not null) 
            throw new InvalidOperationException($"Cpf '{inputCreate.Cpf}' já cadastrado na base de dados.");

        Customer customer = FromInputCreateToEntity(inputCreate);

        return FromEntityToOutput(_repository.Create(customer) ?? new Customer());
    }

    public override OutputCustomer? Update(long id, InputUpdateCustomer inputUpdate)
    {
        Customer? originalCustomer = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException($"Não foi encontrado nenhum cliente correspondente a este Id.");

        Customer customer = UpdateEntity(originalCustomer, inputUpdate) ?? throw new Exception("Problemas para realizar atualização");

        return FromEntityToOutput(_repository!.Update(customer) ?? new Customer());
    }

    public override bool Delete(long id)
    {
        Customer? originalCustomer = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException($"Não foi encontrado nenhum cliente correspondente a este Id.");

        if(originalCustomer.ListOrder?.Count == 0 || originalCustomer.ListOrder is null)
            throw new InvalidOperationException($"Esse cliente possui vínculo com pedidos");

        return true;
    }
}