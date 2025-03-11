using System.ComponentModel.DataAnnotations;

namespace OutfitTrack.Arguments;

public class InputAuthentication(string email, string password)
{
    [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
    [MaxLength(256, ErrorMessage = "O e-mail deve ter no máximo 256 caracteres.")]
    public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;
}