using OutfitTrack.Arguments;

namespace OutfitTrack.Domain.Entities;

public class Order : BaseEntity<Order>
{
    public long? CustomerId { get; private set; }
    public EnumStatusOrder? Status { get; private set; }
    public DateTime? ClosingDate { get; private set; }
    public long? Number { get; private set; }
    public string? Observation { get; private set; }

    public virtual List<OrderItem>? ListOrderItem { get; private set; }
    public virtual Customer? Customer { get; private set; }

    public Order() { }

    public Order(long? customerId, EnumStatusOrder? status, DateTime? closingDate, long? number, string? observation, List<OrderItem>? listOrderItem, Customer? customer)
    {
        CustomerId = customerId;
        Status = status;
        ClosingDate = closingDate;
        Number = number;
        Observation = observation;
        ListOrderItem = listOrderItem;
        Customer = customer;
    }
}