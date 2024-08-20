using System.ComponentModel.DataAnnotations;

namespace OutfitTrack.Arguments;

public class InputCreateProduct
{
    [Required][MaxLength(20, ErrorMessage = "Quantidade de caracteres inválida")] public string? Code { get; set; }
    [Required][MaxLength(100, ErrorMessage = "Quantidade de caracteres inválida")] public string? Description { get; set; }
    [Required] public decimal? Price { get; set; }
    [MaxLength(50, ErrorMessage = "Quantidade de caracteres inválida")] public string? Brand { get; set; }
    [Required] public int? Quantity { get; set; }
    [MaxLength(100, ErrorMessage = "Quantidade de caracteres inválida")] public string? Category { get; set; }

    public InputCreateProduct() { }

    public InputCreateProduct(string code, string description, decimal price, string? brand, int quantity, string? category)
    {
        Code = code;
        Description = description;
        Price = price;
        Brand = brand;
        Quantity = quantity;
        Category = category;
    }
}