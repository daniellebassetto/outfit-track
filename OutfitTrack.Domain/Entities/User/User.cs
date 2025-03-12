namespace OutfitTrack.Domain.Entities;

public class User : BaseEntity<User>
{
    public string? Email { get; private set; }
    public string? Password { get; private set; }
    public DateTime? TokenExpirationDate { get; private set; }

    public User() { }

    public User(string? email, string? password, DateTime? tokenExpirationDate)
    {
        Email = email;
        Password = password;
        TokenExpirationDate = tokenExpirationDate;
    }
}