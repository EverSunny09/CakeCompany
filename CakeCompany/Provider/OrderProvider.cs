using System.Reflection.Metadata.Ecma335;
using CakeCompany.Models;
using CakeCompany.Service;
using Serilog;

namespace CakeCompany.Provider;

internal class OrderProvider : IOrderService
{
    private readonly IOrderService _orderService;
    private readonly ICakeService _cakeService;
    private readonly IPaymentService _paymentService;

    public OrderProvider(IOrderService orderService, ICakeService cakeService, IPaymentService paymentService) {
        _orderService = orderService;
        _cakeService = cakeService;
        _paymentService = paymentService;
    }

    public List<Order> GetLatestOrders()
    {
        return new List<Order>(){
                    new Order { ClientName = "CakeBox", EstimatedDeliveryTime = DateTime.Now, Id = 1, Name = Cake.RedVelvet, Quantity=120 },
                    new Order { ClientName = "ImportantCakeShop", EstimatedDeliveryTime = DateTime.Now, Id = 2, Name = Cake.RedVelvet, Quantity=120 }};
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
        DateTime estimatedBakeTime = _cakeService.Check(order);
        return estimatedBakeTime > order.EstimatedDeliveryTime;
    }

    public bool CheckPaymentProcess(Order order) {
        return _paymentService.Process(order).IsSuccessful;
    }

}


