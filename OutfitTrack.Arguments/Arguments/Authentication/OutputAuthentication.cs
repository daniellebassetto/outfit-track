namespace OutfitTrack.Arguments;

public class OutputAuthentication(string token, DateTime? tokenExpirationDate)
{
    public string? Token { get; set; } = token;
    public DateTime? TokenExpirationDate { get; set; } = tokenExpirationDate;
}