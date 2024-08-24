using Newtonsoft.Json;

namespace OutfitTrack.Arguments;

public class InputCreateOrder
{
    public long? CustomerId { get; private set; }
    public string? Observation { get; private set; }
    public List<InputCreateOrderItem>? ListCreatedItem { get; private set; }

    public InputCreateOrder() { }

    [JsonConstructor]
    public InputCreateOrder(long customerId, string? observation, List<InputCreateOrderItem> listCreatedItem)
    {
        CustomerId = customerId;
        Observation = observation;
        ListCreatedItem = listCreatedItem;
    }
}