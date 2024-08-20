using Newtonsoft.Json;

namespace OutfitTrack.Arguments;

public class InputIdentifierOrder
{
    public long? Number { get; private set; }

    public InputIdentifierOrder() { }

    [JsonConstructor]
    public InputIdentifierOrder(long number)
    {
        Number = number;
    }
}