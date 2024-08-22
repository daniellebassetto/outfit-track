using Newtonsoft.Json;

namespace OutfitTrack.Arguments;

public class InputIdentifierOrderItem
{
    public long? ProductId { get; private set; }

    public InputIdentifierOrderItem() { }

    [JsonConstructor]
    public InputIdentifierOrderItem(long? productId)
    {
        ProductId = productId;
    }
}