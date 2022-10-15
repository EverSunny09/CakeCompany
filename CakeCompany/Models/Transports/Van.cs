using CakeCompany.Service;

namespace CakeCompany.Models.Transports;

internal class Van : IDeliveryService
{
    public bool Deliver(List<Product> products)
    {
        return true;
    }
}