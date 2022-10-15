using CakeCompany.Models;

namespace CakeCompany.Service
{
    public interface ICakeService
    {

        Product Bake(Order order);

        List<Product> GetProducts();

    }
}
