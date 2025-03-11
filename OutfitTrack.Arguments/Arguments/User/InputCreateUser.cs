using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace OutfitTrack.Arguments;

public class InputCreateUser
{
    [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
    [MaxLength(256, ErrorMessage = "O e-mail deve ter no máximo 256 caracteres.")]
    public string? Email { get; private set; }

    [MinLength(8, ErrorMessage = "A senha deve ter pelo menos 8 caracteres.")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "A senha deve conter pelo menos uma letra maiúscula, um número e um caractere especial.")]
    public string? Password { get; private set; }

    [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
    public string? ConfirmPassword { get; private set; }

    public InputCreateUser() { }

    [JsonConstructor]
    public InputCreateUser(string email, string password, string confirmPassword)
    {
        Email = email;
        Password = password;
        ConfirmPassword = confirmPassword;
    }
}