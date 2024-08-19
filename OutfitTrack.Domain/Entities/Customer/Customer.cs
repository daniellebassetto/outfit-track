namespace OutfitTrack.Domain.Entities;

public class Customer : BaseEntity<Customer>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Cpf { get; set; }
    public string? Street { get; set; }
    public string? Complement { get; set; }
    public string? Neighborhood { get; set; }
    public string? Number { get; set; }
    public string? CityName { get; set; }
    public string? StateAbbreviation { get; set; }
    public string? Rg { get; set; }
    public string? MobilePhoneNumber { get; set; }
    public string? Email { get; set; }

    public Customer() { }

    public Customer(string? firstName, string? lastName, DateTime? birthDate, string? cpf, string? street, string? complement, string? neighborhood, string? number, string? cityName, string? stateAbbreviation, string? rg, string? mobilePhoneNumber, string? email)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Cpf = cpf;
        Street = street;
        Complement = complement;
        Neighborhood = neighborhood;
        Number = number;
        CityName = cityName;
        StateAbbreviation = stateAbbreviation;
        Rg = rg;
        MobilePhoneNumber = mobilePhoneNumber;
        Email = email;
    }
}