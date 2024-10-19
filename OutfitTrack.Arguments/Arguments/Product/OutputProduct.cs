namespace OutfitTrack.Arguments;

public class OutputProduct
{
    public long Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? ChangeDate { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public string? Brand { get; set; }
    public string? Category { get; set; }
}