namespace OutfitTrack.Arguments;

public class OutputOrder
{
    public long Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? ChangeDate { get; set; }
    public long? ClientId { get; set; }
    public EnumStatusOrder? Status { get; set; }
    public DateTime? ClosingDate { get; set; }    
}