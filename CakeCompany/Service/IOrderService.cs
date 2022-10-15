using CakeCompany.Models;

namespace CakeCompany.Service;

interface IOrderService
{
    List<Order> GetLatestOrders();

    void UpdateOrders(List<Order> orders);

    List<Order> CancelledOrders();

    List<Order> GetOrderToBake();

    bool CheckEstimatedTime(Order order);

    bool CheckPaymentProcess(Order order);
}