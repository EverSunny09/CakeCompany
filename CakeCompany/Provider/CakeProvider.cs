using CakeCompany.Models;
using CakeCompany.Service;
using Serilog;

namespace CakeCompany.Provider;

public class CakeProvider : ICakeService 
{

    private readonly IOrderService _orderService;
    
    public CakeProvider(IOrderService orderService) {
        _orderService = orderService;
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
                Product product = Bake(order);
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