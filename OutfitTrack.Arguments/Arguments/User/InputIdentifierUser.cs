using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace OutfitTrack.Arguments;

public class InputIdentifierUser
{
    [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
    [MaxLength(256, ErrorMessage = "O e-mail deve ter no máximo 256 caracteres.")]
    public string? Email { get; private set; }

    public InputIdentifierUser() { }

    [JsonConstructor]
    public InputIdentifierUser(string? email)
    {
        Email = email;
    }
}