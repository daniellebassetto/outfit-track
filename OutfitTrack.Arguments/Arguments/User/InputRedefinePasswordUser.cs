using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace OutfitTrack.Arguments;

public class InputRedefinePasswordUser
{
    [MinLength(8, ErrorMessage = "A senha deve ter pelo menos 8 caracteres.")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "A senha deve conter pelo menos uma letra maiúscula, um número e um caractere especial.")]
    public string? Password { get; private set; }

    [MinLength(8, ErrorMessage = "A senha deve ter pelo menos 8 caracteres.")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "A senha deve conter pelo menos uma letra maiúscula, um número e um caractere especial.")]
    public string? NewPassword { get; private set; }

    [MinLength(8, ErrorMessage = "A senha deve ter pelo menos 8 caracteres.")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "A senha deve conter pelo menos uma letra maiúscula, um número e um caractere especial.")]
    [Compare("NewPassword", ErrorMessage = "As novas senhas não coincidem.")]
    public string? ConfirmNewPassword { get; private set; }

    public InputRedefinePasswordUser() { }

    [JsonConstructor]
    public InputRedefinePasswordUser(string password, string newPassword, string confirmNewPassword)
    {
        Password = password;
        NewPassword = newPassword;
        ConfirmNewPassword = confirmNewPassword;
    }
}