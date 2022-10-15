using CakeCompany.Models;
using CakeCompany.Provider;
using CakeCompany.Service;
using NUnit.Framework;
using System;

namespace CakeCompany.UnitTest
{
    public class UnitTest
    {
        Order order = new Order();
        [SetUp]
        public void Setup()
        {
        }

        public void GetShipment()
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
