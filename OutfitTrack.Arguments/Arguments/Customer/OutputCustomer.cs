namespace OutfitTrack.Arguments;

public class OutputCustomer
{
    public long Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? ChangeDate { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Cpf { get; set; }
    public string? Street { get; set; }
    public string? Complement { get; set; }
    public string? Neighborhood { get; set; }
    public string? Number { get; set; }
    public string? CityName { get; set; }
    public EnumStateAbbreviationBrazil? StateAbbreviation { get; set; }
    public string? PostalCode { get; set; }
    public string? Rg { get; set; }
    public string? MobilePhoneNumber { get; set; }
    public string? Email { get; set; }

    public virtual List<OutputOrder>? ListOrder { get; set; }
}