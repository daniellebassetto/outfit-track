using Newtonsoft.Json;

namespace OutfitTrack.Arguments;

public class InputUpdateOrderItem
{
    public string? Color { get; private set; }
    public string? Size { get; private set; }
    public EnumStatusOrderItem? Status { get; private set; }

    public InputUpdateOrderItem() { }

    [JsonConstructor]
    public InputUpdateOrderItem(string? color, string? size, EnumStatusOrderItem? status)
    {
        Color = color;
        Size = size;
        Status = status;
    }
}