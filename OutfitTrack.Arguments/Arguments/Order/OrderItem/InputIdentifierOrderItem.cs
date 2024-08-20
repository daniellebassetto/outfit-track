using Newtonsoft.Json;

namespace OutfitTrack.Arguments;

public class InputIdentifierOrderItem
{
    public int? Item { get; private set; }

    public InputIdentifierOrderItem() { }

    [JsonConstructor]
    public InputIdentifierOrderItem(int? item)
    {
        Item = item;
    }
}