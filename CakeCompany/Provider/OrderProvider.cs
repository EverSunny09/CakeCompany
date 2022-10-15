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

    public List<Order> GetLatestOrders()
    {
         return new List<Order>(){
                    new Order { ClientName = "CakeBox", EstimatedDeliveryTime = DateTime.Now, Id = 1, Name = Cake.RedVelvet, Quantity=120 },
                    new Order { ClientName = "ImportantCakeShop", EstimatedDeliveryTime = DateTime.Now, Id = 1, Name = Cake.RedVelvet, Quantity=120 }};
       
    }

    public void UpdateOrders(List<Order> orders)
    {
    }

    public List<Order> CancelledOrders() {
        List<Order> cancelledOrders = new List<Order>();
        List<Order> orders = GetLatestOrders();
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
            else if (!checkPaymentProcess(order)) {
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


