using CakeCompany.Service;

namespace CakeCompany.Models.Transports;
public class Ship : IDeliveryService
{
    public bool Deliver(List<Product> products)
    {
        return true;
    }
}