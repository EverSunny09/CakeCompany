namespace CakeCompany.Models;

internal class Product
{
    public int Id { get; set; }
    public Cake Cake { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }
}
