namespace CakeCompany.Models;

internal class Product
{
    public Guid Id { get; set; }
    public Cake Cake { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }
}
