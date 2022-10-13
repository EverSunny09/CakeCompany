using System.Reflection.Metadata.Ecma335;
using CakeCompany.Models;
using CakeCompany.Service;

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

    public Order[] GetLatestOrders()
    {
        return new Order[]
        {
            new("CakeBox", DateTime.Now, 1, Cake.RedVelvet, 120.25),
            new("ImportantCakeShop", DateTime.Now, 1, Cake.RedVelvet, 120.25)
        };
    }

    public void UpdateOrders(Order[] orders)
    {
    }

    public List<Order> CancelledOrders() {
        List<Order> cancelledOrders = new List<Order>();
        Order[] orders = GetLatestOrders();
        if (!orders.Any())
        {
            return new List<Order>();
        }
        foreach (Order order in orders)
        {
            if (checkEstimationTime(order))
            {
                cancelledOrders.Add(order);
            }
            if (!checkPaymentProcess(order)) {
                cancelledOrders.Add(order);
            }
        }
        return cancelledOrders;
        
    }

    public bool checkEstimationTime(Order order) {
        DateTime estimatedBakeTime = _cakeService.Check(order);
        return estimatedBakeTime > order.EstimatedDeliveryTime;
    }

    public bool checkPaymentProcess(Order order) {
        return _paymentService.Process(order).IsSuccessful;
    }

}


