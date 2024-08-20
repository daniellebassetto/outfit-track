using Newtonsoft.Json;

namespace OutfitTrack.Arguments;

public class InputIdentifierProduct
{
    public string? Code { get; private set; }

    public InputIdentifierProduct() { }

    [JsonConstructor]
    public InputIdentifierProduct(string code)
    {
        Code = code;
    }
}