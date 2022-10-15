using CakeCompany.Service;

namespace CakeCompany.Models.Transports;


internal class Truck : IDeliveryService
{
    public bool Deliver(List<Product> products)
    {
        return true;
    }
}