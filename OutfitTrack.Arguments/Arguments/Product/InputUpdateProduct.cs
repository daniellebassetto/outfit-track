using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace OutfitTrack.Arguments;

public class InputUpdateProduct
{
    [MaxLength(100, ErrorMessage = "A descrição deve ter no máximo 100 caracteres.")]
    public string? Description { get; private set; }

    [Range(0.01, 10000.00, ErrorMessage = "O preço deve estar entre 0,01 e 10.000,00.")]
    public decimal? Price { get; private set; }

    [MaxLength(50, ErrorMessage = "A marca deve ter no máximo 50 caracteres.")]
    public string? Brand { get; private set; }

    [MaxLength(100, ErrorMessage = "A categoria deve ter no máximo 100 caracteres.")]
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