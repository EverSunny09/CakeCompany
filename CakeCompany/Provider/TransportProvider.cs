using CakeCompany.Models;
using CakeCompany.Service;

namespace CakeCompany.Provider;

internal class TransportProvider : ITransportService
{
    public Transport CheckForAvailability(List<Product> products)
    {
        if (products.Sum(p => p.Quantity) < 1000)
        {
            return Transport.Van;
        }

        if (products.Sum(p => p.Quantity) > 1000 && products.Sum(p => p.Quantity) < 5000)
        {
            return Transport.Truck;
        }

        return Transport.Ship;
    }

    public bool Deliver(List<Product> products)
    {
        return true;
    }
}
