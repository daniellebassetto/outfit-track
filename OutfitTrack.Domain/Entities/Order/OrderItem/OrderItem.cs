using OutfitTrack.Arguments;

namespace OutfitTrack.Domain.Entities;

public class OrderItem : BaseEntity<OrderItem>
{
    public int? Item { get; private set; }
    public long? OrderId { get; private set; }
    public long? ProductId { get; private set; }
    public string? Variation { get; private set; }
    public EnumStatusOrderItem? Status { get; private set; }

    public virtual Product? Product { get; private set; }
    public virtual Order? Order { get; private set; }

    public OrderItem() { }

    public OrderItem(int? item, long? orderId, long? productId, string? variation, EnumStatusOrderItem? status, Product? product, Order? order)
    {
        Item = item;
        OrderId = orderId;
        ProductId = productId;
        Variation = variation;
        Status = status;
        Product = product;
        Order = order;
    }
}