using Newtonsoft.Json;

namespace OutfitTrack.Arguments;

public class InputIdentifierOrderItem
{
    public long? OrderId { get; private set; }
    public long? ProductId { get; private set; }

    public InputIdentifierOrderItem() { }

    [JsonConstructor]
    public InputIdentifierOrderItem(long orderId, long productId)
    {
        OrderId = orderId;
        ProductId = productId;
    }
}