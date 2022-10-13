using CakeCompany.Models;

namespace CakeCompany.Service;

interface IOrderService
{
    Order[] GetLatestOrders();

    void UpdateOrders(Order[] orders);

    List<Order> CancelledOrders();
}