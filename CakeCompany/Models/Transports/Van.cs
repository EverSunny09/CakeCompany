using CakeCompany.Service;

namespace CakeCompany.Models.Transports;

public class Van : IDeliveryService
{
    public bool Deliver(List<Product> products)
    {
        return true;
    }
}