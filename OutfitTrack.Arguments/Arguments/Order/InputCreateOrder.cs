using Newtonsoft.Json;

namespace OutfitTrack.Arguments;

public class InputCreateOrder
{
    public long? CustomerId { get; private set; }
    public List<InputCreateOrderItem>? ListOrderItem { get; private set; }

    public InputCreateOrder() { }

    [JsonConstructor]
    public InputCreateOrder(long customerId, List<InputCreateOrderItem> listOrderItem)
    {
        CustomerId = customerId;
        ListOrderItem = listOrderItem;
    }
}