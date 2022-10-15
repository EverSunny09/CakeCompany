using CakeCompany.Models;
using CakeCompany.Service;
using Serilog;

namespace CakeCompany.Provider;

public class OrderProvider : IOrderService
{
    private readonly IPaymentService _paymentService;

    public OrderProvider(IPaymentService paymentService) {
        _paymentService = paymentService;
    }

    public List<Order> GetLatestOrders()
    {
        return new List<Order>(){
                    new Order { ClientName = "CakeBox", EstimatedDeliveryTime = DateTime.Now.AddHours(2), Id = 1, Name = Cake.RedVelvet, Quantity=3000 },
                    new Order { ClientName = "ImportantCakeShop", EstimatedDeliveryTime = DateTime.Now.AddHours(2), Id = 2, Name = Cake.RedVelvet, Quantity=120 }};
    }

    public void UpdateOrders(List<Order> orders)
    {
    }

    public List<Order> CancelledOrders() {
        List<Order> cancelledOrders = new List<Order>();
        try {
            List<Order> orders = GetLatestOrders();
            if (!orders.Any())
            {
                return new List<Order>();
            }
            foreach (Order order in orders)
            {
                if (CheckEstimatedTime(order) || !CheckPaymentProcess(order))
                {
                    cancelledOrders.Add(order);
                }
            }
        }
        catch (Exception e) {
            Log.Error(e.ToString());
        }
       
        return cancelledOrders;
        
    }

    public List<Order> GetOrderToBake() {
        List<Order> ordersToBake = new List<Order>();
        Log.Information("Getting list of all orders.");
        List<Order> orders = GetLatestOrders();
        Log.Information("Getting list of orders which are not cancelled.");
        foreach (Order order in orders)
        {
            if (!CheckEstimatedTime(order) && CheckPaymentProcess(order))
            {
                ordersToBake.Add(order);
            }
        }
        return ordersToBake;
    }

    public bool CheckEstimatedTime(Order order) {
        DateTime estimatedBakeTime = Check(order);
        return estimatedBakeTime > order.EstimatedDeliveryTime;
    }

    public DateTime Check(Order order)
    {
        switch (order.Name)
        {
            case Cake.Chocolate:
                return DateTime.Now.Add(TimeSpan.FromMinutes(30));
            case Cake.RedVelvet:
                return DateTime.Now.Add(TimeSpan.FromMinutes(60));
            default:
                return DateTime.Now.Add(TimeSpan.FromHours(15));
        }
    }

    public bool CheckPaymentProcess(Order order) {
        return _paymentService.Process(order).IsSuccessful;
    }

}


