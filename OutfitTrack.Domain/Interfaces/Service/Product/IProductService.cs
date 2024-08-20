using OutfitTrack.Arguments;

namespace OutfitTrack.Domain.Interfaces.Service;

public interface IProductService : IBaseService<InputCreateProduct, InputUpdateProduct, OutputProduct, InputIdentifierProduct> { }