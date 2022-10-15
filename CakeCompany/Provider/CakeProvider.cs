using CakeCompany.Models;
using CakeCompany.Service;
using Serilog;

namespace CakeCompany.Provider;

internal class CakeProvider : ICakeService 
{

    private readonly ICakeService _cakeService;
    private readonly IOrderService _orderService;
    
    public CakeProvider(IOrderService orderService, ICakeService cakeService) {
        _cakeService = cakeService;
        _orderService = orderService;
 
    }

    public DateTime Check(Order order)
    {
        switch (order.Name) {
            case Cake.Chocolate:
                return DateTime.Now.Add(TimeSpan.FromMinutes(30));
            case Cake.RedVelvet:
                return DateTime.Now.Add(TimeSpan.FromMinutes(60));
            default:
                return DateTime.Now.Add(TimeSpan.FromHours(15));
        }
    }

    public Product Bake(Order order)
    {
        switch (order.Name)
        {
            case Cake.Chocolate:
                return new Product(new Guid(), Cake.Chocolate, order.Quantity, order.Id);
               
            case Cake.RedVelvet:
                return new Product(new Guid(), Cake.RedVelvet, order.Quantity, order.Id);
            default:
                return new Product(new Guid(), Cake.Vanilla, order.Quantity, order.Id);
        }
    }

    public List<Product> GetProducts() {
        List<Product> products = new List<Product>();
        try
        {
            List<Order> orders = _orderService.GetOrderToBake();
            foreach (Order order in orders)
            {
                Product product = _cakeService.Bake(order);
                products.Add(product);
            }
        }
        catch (Exception e)
        {
            Log.Error(e.ToString());
        }
        return products;
    }

}