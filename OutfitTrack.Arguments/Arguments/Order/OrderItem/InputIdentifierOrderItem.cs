using Newtonsoft.Json;

namespace OutfitTrack.Arguments;

public class InputIdentifierOrderItem
{
    public int? Item { get; private set; }
    public long? OrderId { get; private set; }

    public InputIdentifierOrderItem() { }

    [JsonConstructor]
    public InputIdentifierOrderItem(int? item, long? orderId)
    {
        Item = item;
        OrderId = orderId;
    }
}