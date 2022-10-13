using CakeCompany.Models;
using CakeCompany.Service;

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
        if (order.Name == Cake.Chocolate)
        {
            return DateTime.Now.Add(TimeSpan.FromMinutes(30));
        }

        if (order.Name == Cake.RedVelvet)
        {
            return DateTime.Now.Add(TimeSpan.FromMinutes(60));
        }

        return DateTime.Now.Add(TimeSpan.FromHours(15));
    }

    public Product Bake(Order order)
    {
        if (order.Name == Cake.Chocolate)
        {
            return new()
            {
                Cake = Cake.Chocolate,
                Id = new Guid(),
                Quantity = order.Quantity
            };
        }

        if (order.Name == Cake.RedVelvet)
        {
            return new()
            {
                Cake = Cake.RedVelvet,
                Id = new Guid(),
                Quantity = order.Quantity
            };
        }

        return new()
        {
            Cake = Cake.Vanilla,
            Id = new Guid(),
            Quantity = order.Quantity
        };
    }

    public List<Product> GetProducts() {
        List<Product> products = new List<Product>();
        Order[] orders = _orderService.GetLatestOrders();
        foreach (Order order in orders) {
            Product product = _cakeService.Bake(order);
            products.Add(product);
        }
        return products;
    }

}