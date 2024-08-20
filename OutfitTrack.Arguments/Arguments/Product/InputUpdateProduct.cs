using System.ComponentModel.DataAnnotations;

namespace OutfitTrack.Arguments;

public class InputUpdateProduct
{
    [Required][MaxLength(100, ErrorMessage = "Quantidade de caracteres inválida")] public string? Description { get; set; }
    [Required] public decimal? Price { get; set; }
    [Required][MaxLength(10, ErrorMessage = "Quantidade de caracteres inválida")] public string? Size { get; set; }
    [MaxLength(30, ErrorMessage = "Quantidade de caracteres inválida")] public string? Color { get; set; }
    [MaxLength(50, ErrorMessage = "Quantidade de caracteres inválida")] public string? Brand { get; set; }
    [Required] public int? Quantity { get; set; }
    [MaxLength(100, ErrorMessage = "Quantidade de caracteres inválida")] public string? Category { get; set; }

    public InputUpdateProduct() { }

    public InputUpdateProduct(string description, decimal price, string size, string? color, string? brand, int quantity, string? category)
    {
        Description = description;
        Price = price;
        Size = size;
        Color = color;
        Brand = brand;
        Quantity = quantity;
        Category = category;
    }
}