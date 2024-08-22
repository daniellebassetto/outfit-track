using Newtonsoft.Json;
using OutfitTrack.Arguments.Arguments;

namespace OutfitTrack.Arguments;

public class InputUpdateOrder
{
    public string? Observation { get; private set; }
    public List<InputCreateOrderItem>? ListCreatedItem { get; private set; }
    public List<InputIdentityUpdateOrderItem>? ListUpdatedItem { get; private set; }
    public List<long>? ListDeletedItem { get; private set; }

    public InputUpdateOrder() { }

    [JsonConstructor]
    public InputUpdateOrder(string? observation, List<InputCreateOrderItem>? listCreatedItem, List<InputIdentityUpdateOrderItem>? listUpdatedItem, List<long>? listDeletedItem)
    {
        Observation = observation;
        ListCreatedItem = listCreatedItem;
        ListUpdatedItem = listUpdatedItem;
        ListDeletedItem = listDeletedItem;
    }
}