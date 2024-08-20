using Newtonsoft.Json;

namespace OutfitTrack.Arguments;

public class InputCreateOrder
{
    public long? Number { get; private set; }
    public long? CustomerId { get; private set; }
    public List<InputCreateOrderItem>? ListOrderItem { get; private set; }

    public InputCreateOrder() { }

    [JsonConstructor]
    public InputCreateOrder(long number, long customerId, List<InputCreateOrderItem> listOrderItem)
    {
        Number = number;
        CustomerId = customerId;
        ListOrderItem = listOrderItem;
    }
}