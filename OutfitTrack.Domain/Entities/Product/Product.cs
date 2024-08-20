namespace OutfitTrack.Domain.Entities;

public class Product : BaseEntity<Product>
{
    public string? Code { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public string? Brand { get; set; }
    public int? Quantity { get; set; }
    public string? Category { get; set; }

    public virtual List<OrderItem>? ListOrderItem { get; set; }

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