namespace CakeCompany.Models;

//internal record Order(string ClientName, DateTime EstimatedDeliveryTime, int Id, Cake Name, double Quantity);

public class Order
{
    public string ClientName { get; set; }
    public DateTime EstimatedDeliveryTime { get; set; }

    public int Id { get; set; }

    public Cake Name { get; set; }

    public int Quantity { get; set; }

}