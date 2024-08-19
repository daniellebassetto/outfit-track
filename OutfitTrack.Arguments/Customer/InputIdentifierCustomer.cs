using System.ComponentModel.DataAnnotations;

namespace OutfitTrack.Arguments;

public class InputIdentifierCustomer
{
    [Required][Length(11, 11, ErrorMessage = "Quantidade de caracteres inválida")] public string? Cpf { get; set; }

    public InputIdentifierCustomer() { }

    public InputIdentifierCustomer(string? cpf)
    {
        Cpf = cpf;
    }
}