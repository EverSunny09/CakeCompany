using CakeCompany.Service;

namespace CakeCompany.Models.Transports;


public class Truck : IDeliveryService
{
    public bool Deliver(List<Product> products)
    {
        return true;
    }
}