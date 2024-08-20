using OutfitTrack.Arguments;

namespace OutfitTrack.Domain.Entities;

public class OrderItem : BaseEntity<OrderItem>
{
    public long? OrderId { get; set; }
    public long? ProductId { get; set; }
    public string? Color { get; set; }
    public string? Size { get; set; }
    public EnumStatusOrderItem? Status { get; set; }

    public virtual Product? Product { get; set; }
    public virtual Order? Order { get; set; }

    public OrderItem() { }

    public OrderItem(long? orderId, long? productId, string? color, string? size, EnumStatusOrderItem? status, Product? product, Order? order)
    {
        OrderId = orderId;
        ProductId = productId;
        Color = color;
        Size = size;
        Status = status;
        Product = product;
        Order = order;
    }
}