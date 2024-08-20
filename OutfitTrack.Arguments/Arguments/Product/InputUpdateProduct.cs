using Newtonsoft.Json;

namespace OutfitTrack.Arguments;

public class InputUpdateProduct
{
    public string? Description { get; private set; }
    public decimal? Price { get; private set; }
    public string? Size { get; private set; }
    public string? Color { get; private set; }
    public string? Brand { get; private set; }
    public string? Category { get; private set; }

    public InputUpdateProduct() { }

    [JsonConstructor]
    public InputUpdateProduct(string description, decimal price, string size, string? color, string? brand, string? category)
    {
        Description = description;
        Price = price;
        Size = size;
        Color = color;
        Brand = brand;
        Category = category;
    }
}