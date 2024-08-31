using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace OutfitTrack.Arguments;

public class InputCreateProduct
{
    [MaxLength(20, ErrorMessage = "O código deve ter no máximo 20 caracteres.")]
    public string? Code { get; private set; }

    [MaxLength(100, ErrorMessage = "A descrição deve ter no máximo 100 caracteres.")]
    public string? Description { get; private set; }

    public decimal? Price { get; private set; }

    [MaxLength(50, ErrorMessage = "A marca deve ter no máximo 50 caracteres.")]
    public string? Brand { get; private set; }

    [MaxLength(100, ErrorMessage = "A categoria deve ter no máximo 100 caracteres.")]
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