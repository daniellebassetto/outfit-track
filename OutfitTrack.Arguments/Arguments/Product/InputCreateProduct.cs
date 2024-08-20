using Newtonsoft.Json;

namespace OutfitTrack.Arguments;

public class InputCreateProduct
{
    public string? Code { get; private set; }
    public string? Description { get; private set; }
    public decimal? Price { get; private set; }
    public string? Brand { get; private set; }
    public string? Category { get; private set; }

    public InputCreateProduct() { }

    [JsonConstructor]
    public InputCreateProduct(string code, string description, decimal price, string? brand, string? category)
    {
        Code = code;
        Description = description;
        Price = price;
        Brand = brand;
        Category = category;
    }
}