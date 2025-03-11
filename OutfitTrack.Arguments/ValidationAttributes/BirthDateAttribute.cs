using System.ComponentModel.DataAnnotations;

namespace OutfitTrack.Arguments;

public class BirthDateAttribute : ValidationAttribute
{
    private const int _minAge = 18;

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age))
                age--;

            if (age < _minAge)
                return new ValidationResult($"É necessário ter pelo menos {_minAge} anos.");

            return ValidationResult.Success;
        }

        return new ValidationResult("Data de nascimento inválida.");
    }
}