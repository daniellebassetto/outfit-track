using Newtonsoft.Json;

namespace OutfitTrack.Arguments;

public class InputIdentifierCustomer
{
    public string? Cpf { get; private set; }

    public InputIdentifierCustomer() { }

    [JsonConstructor]
    public InputIdentifierCustomer(string? cpf)
    {
        Cpf = cpf;
    }
}