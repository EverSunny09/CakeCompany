using CakeCompany.Service;

namespace CakeCompany.Models.Transports;
internal class Ship : IDeliveryService
{
    public bool Deliver(List<Product> products)
    {
        return true;
    }
}