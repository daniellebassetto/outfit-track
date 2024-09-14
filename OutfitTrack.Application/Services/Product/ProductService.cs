using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces;
using OutfitTrack.Application.Interfaces;

namespace OutfitTrack.Application.Services;

public class ProductService(IUnitOfWork unitOfWork) : BaseService<IProductRepository, InputCreateProduct, InputUpdateProduct, Product, OutputProduct, InputIdentifierProduct>(unitOfWork), IProductService
{
    public override OutputProduct Create(InputCreateProduct inputCreate)
    {
        Product? originalProduct = _repository!.GetByIdentifier(new InputIdentifierProduct(inputCreate.Code!));

        if (originalProduct is not null)
            throw new InvalidOperationException($"Código '{inputCreate.Code}' já cadastrado na base de dados.");

        if(inputCreate.Price == 0)
            throw new InvalidOperationException($"Valor do produto inválido.");

        Product product = FromInputCreateToEntity(inputCreate);
        var entity = _repository.Create(product) ?? throw new InvalidOperationException("Falha ao criar a produto.");
        _unitOfWork!.Commit();

        return FromEntityToOutput(entity);
    }

    public override OutputProduct Update(long id, InputUpdateProduct inputUpdate)
    {
        Product? originalProduct = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException($"Não foi encontrado nenhum produto correspondente a este Id.");

        if (inputUpdate.Price == 0)
            throw new InvalidOperationException($"Valor do produto inválido.");

        Product product = UpdateEntity(originalProduct, inputUpdate) ?? throw new Exception("Problemas para realizar atualização");
        var entity = _repository!.Update(product) ?? throw new InvalidOperationException("Falha ao atualizar o produto.");
        _unitOfWork!.Commit();

        return FromEntityToOutput(entity);
    }

    public override bool Delete(long id)
    {
        Product? originalProduct = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException($"Não foi encontrado nenhum produto correspondente a este Id.");

        if (originalProduct.ListOrderItem?.Count > 0)
            throw new InvalidOperationException($"Esse produto possui vínculo com itens de pedido");

        _repository.Delete(originalProduct);
        _unitOfWork!.Commit();

        return true;
    }
}