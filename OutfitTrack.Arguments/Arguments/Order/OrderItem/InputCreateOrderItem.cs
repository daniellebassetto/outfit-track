using Newtonsoft.Json;

namespace OutfitTrack.Arguments;

public class InputCreateOrderItem
{
    public long? OrderId { get; private set; }
    public long? ProductId { get; private set; }
    public string? Color { get; private set; }
    public string? Size { get; private set; }

    public InputCreateOrderItem() { }

    [JsonConstructor]
    public InputCreateOrderItem(long orderId, long productId, string? color, string? size)
    {
        OrderId = orderId;
        ProductId = productId;
        Color = color;
        Size = size;
    }
}