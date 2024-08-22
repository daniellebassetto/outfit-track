using Newtonsoft.Json;

namespace OutfitTrack.Arguments;

public class InputUpdateOrderItem
{
    public string? Variation { get; private set; }
    public int? Quantity { get; private set; }
    public EnumStatusOrderItem? Status { get; private set; }

    public InputUpdateOrderItem() { }

    [JsonConstructor]
    public InputUpdateOrderItem(string variation, int quantity, EnumStatusOrderItem status)
    {
        Variation = variation;
        Quantity = quantity;
        Status = status;
    }
}