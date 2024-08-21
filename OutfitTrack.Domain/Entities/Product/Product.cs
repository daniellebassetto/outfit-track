namespace OutfitTrack.Domain.Entities;

public class Product : BaseEntity<Product>
{
    public string? Code { get; private set; }
    public string? Description { get; private set; }
    public decimal? Price { get; private set; }
    public string? Brand { get; private set; }
    public int? Quantity { get; private set; }
    public string? Category { get; private set; }

    public virtual List<OrderItem>? ListOrderItem { get; private set; }

    public Product() { }

    public Product(string? code, string? description, decimal? price, string? brand, int? quantity, string? category, List<OrderItem>? listOrderItem)
    {
        Code = code;
        Description = description;
        Price = price;
        Brand = brand;
        Quantity = quantity;
        Category = category;
        ListOrderItem = listOrderItem;
    }
}