namespace OutfitTrack.Arguments;

public class OutputUser
{
    public long? Id { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateTime? TokenExpirationDate { get; set; }
}