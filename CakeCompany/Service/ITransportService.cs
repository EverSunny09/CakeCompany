using CakeCompany.Models;

namespace CakeCompany.Service
{
    public interface ITransportService
    {
        Transport CheckForAvailability(List<Product> products);
    }
}
