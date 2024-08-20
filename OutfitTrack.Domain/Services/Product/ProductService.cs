using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces.Repository;
using OutfitTrack.Domain.Interfaces.Service;

namespace OutfitTrack.Domain.Services;

public class ProductService(IProductRepository repository) : BaseService<IProductRepository, InputCreateProduct, InputUpdateProduct, Product, OutputProduct, InputIdentifierProduct>(repository), IProductService { }