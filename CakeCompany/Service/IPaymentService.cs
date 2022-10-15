using CakeCompany.Models;

namespace CakeCompany.Service
{
    public interface IPaymentService
    {
        PaymentIn Process(Order order);
    }
}
