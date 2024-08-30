using Newtonsoft.Json;

namespace OutfitTrack.Arguments;

public class InputCreateOrderItem
{
    public long? ProductId { get; private set; }
    public string? Variation { get; private set; }

    public InputCreateOrderItem() { }

    [JsonConstructor]
    public InputCreateOrderItem(long productId, string variation)
    {
        ProductId = productId;
        Variation = variation;
    }
}