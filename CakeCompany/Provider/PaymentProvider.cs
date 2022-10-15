using CakeCompany.Models;
using CakeCompany.Service;

namespace CakeCompany.Provider;

public class PaymentProvider : IPaymentService
{
    public PaymentIn Process(Order order)
    {
        if (order.ClientName.Contains("Important"))
        {
            return new PaymentIn
            {
                HasCreditLimit = false,
                IsSuccessful = true
            };
        }

        return new PaymentIn
        {
            HasCreditLimit = true,
            IsSuccessful = true
        };
    }
}