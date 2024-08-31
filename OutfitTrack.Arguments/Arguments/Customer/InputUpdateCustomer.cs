using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace OutfitTrack.Arguments;

public class InputUpdateCustomer
{
    [MaxLength(50, ErrorMessage = "O primeiro nome deve ter no máximo 50 caracteres.")]
    public string? FirstName { get; private set; }

    [MaxLength(50, ErrorMessage = "O sobrenome deve ter no máximo 50 caracteres.")]
    public string? LastName { get; private set; }

    public DateTime? BirthDate { get; private set; }

    [MaxLength(100, ErrorMessage = "O endereço deve ter no máximo 100 caracteres.")]
    public string? Street { get; private set; }

    [MaxLength(100, ErrorMessage = "O complemento deve ter no máximo 100 caracteres.")]
    public string? Complement { get; private set; }

    [MaxLength(50, ErrorMessage = "O bairro deve ter no máximo 50 caracteres.")]
    public string? Neighborhood { get; private set; }

    [MaxLength(10, ErrorMessage = "O número deve ter no máximo 10 caracteres.")]
    public string? Number { get; private set; }

    [StringLength(8, MinimumLength = 8, ErrorMessage = "O CEP deve ter exatamente 8 caracteres.")]
    public string? PostalCode { get; private set; }

    [MaxLength(50, ErrorMessage = "O nome da cidade deve ter no máximo 50 caracteres.")]
    public string? CityName { get; private set; }

    public EnumStateAbbreviationBrazil? StateAbbreviation { get; private set; }

    [StringLength(9, MinimumLength = 9, ErrorMessage = "O RG deve ter exatamente 9 caracteres numéricos.")]
    public string? Rg { get; private set; }

    [StringLength(13, MinimumLength = 13, ErrorMessage = "O número de celular deve ter exatamente 13 caracteres numéricos.")]
    public string? MobilePhoneNumber { get; private set; }

    [MaxLength(256, ErrorMessage = "O email deve ter no máximo 256 caracteres.")]
    public string? Email { get; private set; }


    public InputUpdateCustomer() { }

    [JsonConstructor]
    public InputUpdateCustomer(string firstName, string? lastName, DateTime birthDate, string street, string? complement, string neighborhood, string number, string cityName, EnumStateAbbreviationBrazil stateAbbreviation, string? postalCode, string rg, string mobilePhoneNumber, string? email)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Street = street;
        Complement = complement;
        Neighborhood = neighborhood;
        Number = number;
        CityName = cityName;
        StateAbbreviation = stateAbbreviation;
        PostalCode = postalCode;
        Rg = rg;
        MobilePhoneNumber = mobilePhoneNumber;
        Email = email;
    }
}