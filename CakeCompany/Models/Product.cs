namespace CakeCompany.Models;

public class Product
{
    public Guid Id { get; set; }
    public Cake Cake { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }

    public Product(Guid id, Cake cake, int quantity, int orderId)
    {
        Id = id;
        Cake = cake;
        Quantity = quantity;
        OrderId = orderId;
    }
}
