namespace CakeCompany.Models;

internal record Order(string ClientName, DateTime EstimatedDeliveryTime, int Id, Cake Name, double Quantity);

/*internal class Order
{
    public string ClientName { get; set; }
    public DateTime EstimatedDeliveryTime { get; set; }

    public int Id { get; set; }

    public Cake Name { get; set; }

    public double Quantity { get; set; }

}*/