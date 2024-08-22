using Newtonsoft.Json;

namespace OutfitTrack.Arguments;

public class InputUpdateOrder
{
    public List<InputUpdateOrderItem>? ListOrderItem { get; private set; }

    public InputUpdateOrder() { }

    [JsonConstructor]
    public InputUpdateOrder(List<InputUpdateOrderItem> listOrderItem)
    {
        ListOrderItem = listOrderItem;
    }
}