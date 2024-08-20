using System.ComponentModel.DataAnnotations;

namespace OutfitTrack.Arguments;

public class InputIdentifierProduct
{
    [Required][MaxLength(20, ErrorMessage = "Quantidade de caracteres inválida")] public string? Code { get; set; }

    public InputIdentifierProduct() { }

    public InputIdentifierProduct(string? code)
    {
        Code = code;
    }
}