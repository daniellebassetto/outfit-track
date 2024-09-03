using Newtonsoft.Json;

namespace OutfitTrack.Arguments;

public class InputUpdateOrderItem
{
    public string? Variation { get; private set; }
    public EnumStatusOrderItem? Status { get; private set; }

    public InputUpdateOrderItem() { }

    [JsonConstructor]
    public InputUpdateOrderItem(string variation, EnumStatusOrderItem status)
    {
        Variation = variation;
        Status = status;
    }
}