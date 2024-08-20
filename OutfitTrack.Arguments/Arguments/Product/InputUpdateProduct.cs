using Newtonsoft.Json;

namespace OutfitTrack.Arguments;

public class InputUpdateProduct
{
    public string? Description { get; private set; }
    public decimal? Price { get; private set; }
    public string? Brand { get; private set; }
    public string? Category { get; private set; }

    public InputUpdateProduct() { }

    [JsonConstructor]
    public InputUpdateProduct(string description, decimal price, string? brand, string? category)
    {
        Description = description;
        Price = price;
        Brand = brand;
        Category = category;
    }
}