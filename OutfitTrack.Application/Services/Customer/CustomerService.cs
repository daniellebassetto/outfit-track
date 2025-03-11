﻿using OutfitTrack.Application.Interfaces;
using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces;

namespace OutfitTrack.Application.Services;

public class CustomerService(IUnitOfWork unitOfWork) : BaseService<ICustomerRepository, InputCreateCustomer, InputUpdateCustomer, Customer, OutputCustomer, InputIdentifierCustomer>(unitOfWork), ICustomerService
{
    public override OutputCustomer Create(InputCreateCustomer inputCreate)
    {
        Customer? originalCustomer = _repository!.GetByIdentifier(new InputIdentifierCustomer(inputCreate.Cpf));

        if (originalCustomer is not null)
            throw new InvalidOperationException($"Cpf '{inputCreate.Cpf}' já cadastrado.");

        Customer customer = FromInputCreateToEntity(inputCreate);
        var entity = _repository.Create(customer) ?? throw new InvalidOperationException("Falha ao criar o cliente.");
        _unitOfWork!.Commit();

        return FromEntityToOutput(entity);
    }

    public override OutputCustomer Update(long id, InputUpdateCustomer inputUpdate)
    {
        Customer? originalCustomer = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException($"Não foi encontrado nenhum cliente correspondente a este Id.");

        Customer customer = UpdateEntity(originalCustomer, inputUpdate) ?? throw new Exception("Problemas para realizar atualização");
        var entity = _repository!.Update(customer) ?? throw new InvalidOperationException("Falha ao atualizar o cliente.");
        _unitOfWork!.Commit();

        return FromEntityToOutput(entity);
    }

    public override bool Delete(long id)
    {
        Customer? originalCustomer = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException($"Não foi encontrado nenhum cliente correspondente a este Id.");

        if (originalCustomer.ListOrder?.Count > 0)
            throw new InvalidOperationException($"Esse cliente possui vínculo com pedidos");

        _repository.Delete(originalCustomer);
        _unitOfWork!.Commit();

        return true;
    }
}