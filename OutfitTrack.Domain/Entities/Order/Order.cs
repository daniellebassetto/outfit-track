using OutfitTrack.Arguments;

namespace OutfitTrack.Domain.Entities;

public class Order : BaseEntity<Order>
{
    public long? CustomerId { get; set; }
    public EnumStatusOrder? Status { get; set; }
    public DateTime? ClosingDate { get; set; }
    public long? Number { get; set; }
    public virtual List<OrderItem>? ListOrderItem { get; set; }

    public virtual Customer? Customer { get; set; }

    public Order() { }

    public Order(long? customerId, EnumStatusOrder? status, DateTime? closingDate, long? number, List<OrderItem>? listOrderItem, Customer? customer)
    {
        CustomerId = customerId;
        Status = status;
        ClosingDate = closingDate;
        Number = number;
        ListOrderItem = listOrderItem;
        Customer = customer;
    }
}