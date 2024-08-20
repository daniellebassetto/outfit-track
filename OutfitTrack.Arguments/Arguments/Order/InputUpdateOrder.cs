using Newtonsoft.Json;

namespace OutfitTrack.Arguments;

public class InputUpdateOrder
{
    public List<InputCreateOrderItem>? ListOrderItem { get; private set; }

    public InputUpdateOrder() { }

    [JsonConstructor]
    public InputUpdateOrder(List<InputCreateOrderItem> listOrderItem)
    {
        ListOrderItem = listOrderItem;
    }
}