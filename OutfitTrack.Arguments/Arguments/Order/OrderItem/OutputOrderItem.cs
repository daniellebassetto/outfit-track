namespace OutfitTrack.Arguments;

public class OutputOrderItem
{
    public long Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? ChangeDate { get; set; }
    public long? OrderId { get; set; }
    public long? ProductId { get; set; }
    public string? Color { get; set; }
    public string? Size { get; set; }
    public EnumStatusOrderItem? Status { get; set; }

    public OutputProduct? Product { get; set; }
    public OutputOrder? Order { get; set; }
}