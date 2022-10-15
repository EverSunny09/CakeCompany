using CakeCompany.Provider;
using CakeCompany.Service;
using NUnit.Framework;

namespace CakeCompany.UnitTest
{
    public class UnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1, "Jignesh")]
        [TestCase(2, "Rakesh")]
        [TestCase(3, "Not Found")]
        public void Test1(int empId, string name)
        {
            IPaymentService paymentService = new PaymentProvider();
            IOrderService orderService = new OrderProvider(paymentService);
            ITransportService transportService = new TransportProvider();
            ICakeService cakeService = new CakeProvider(orderService);

            IShipmentService shipmentProvider = new ShipmentProvider(transportService, cakeService);

            shipmentProvider.GetShipment();
        }
    }
}
