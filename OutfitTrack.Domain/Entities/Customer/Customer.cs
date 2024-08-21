namespace OutfitTrack.Domain.Entities;

public class Customer : BaseEntity<Customer>
{
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public DateTime? BirthDate { get; private set; }
    public string? Cpf { get; private set; }
    public string? Street { get; private set; }
    public string? Complement { get; private set; }
    public string? Neighborhood { get; private set; }
    public string? Number { get; private set; }
    public string? CityName { get; private set; }
    public string? StateAbbreviation { get; private set; }
    public string? PostalCode { get; private set; }
    public string? Rg { get; private set; }
    public string? MobilePhoneNumber { get; private set; }
    public string? Email { get; private set; }

    public virtual List<Order>? ListOrder { get; private set; }

    public Customer() { }

    public Customer(string? firstName, string? lastName, DateTime? birthDate, string? cpf, string? street, string? complement, string? neighborhood, string? number, string? cityName, string? stateAbbreviation, string? postalCode, string? rg, string? mobilePhoneNumber, string? email, List<Order>? listOrder)
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
        PostalCode = postalCode;
        Rg = rg;
        MobilePhoneNumber = mobilePhoneNumber;
        Email = email;
        ListOrder = listOrder;
    }
}