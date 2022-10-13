using System.Diagnostics;
using CakeCompany.Models;
using CakeCompany.Models.Transports;
using CakeCompany.Service;

namespace CakeCompany.Provider;

internal class ShipmentProvider : IShipmentService
{
    private readonly IShipmentService _shipmentService;
    private readonly IOrderService _orderService;
    private readonly IPaymentService _paymentService;
    private readonly ITransportService _transportService;
    private readonly ICakeService _cakeService;

    public ShipmentProvider(IShipmentService shipmentService, IOrderService orderService, IPaymentService paymentService, ITransportService transportService,
        ICakeService cakeService) {
        _shipmentService = shipmentService;
        _orderService = orderService;
        _paymentService = paymentService;
        _transportService = transportService;
        _cakeService = cakeService;
    }

    public void GetShipment()
    {
        //Call order to get new orders
        //var orderProvider = new OrderProvider();

        //Order[] orders = _orderService.GetLatestOrders();

        //if (!orders.Any())
        //{
          //  return;
        //}

        List<Order> cancelledOrders = _orderService.CancelledOrders();
        List<Product> products = _cakeService.GetProducts();

       // foreach (Order order in orders)
       // {
            //var cakeProvider = new CakeProvider();

          //  DateTime estimatedBakeTime = _cakeService.Check(order);

           // if (estimatedBakeTime > order.EstimatedDeliveryTime)
           // {
             //   cancelledOrders.Add(order);
             //   continue;
           // }

            //var payment = new PaymentProvider();

           // if (!_paymentService.Process(order).IsSuccessful)
          //  {
               // cancelledOrders.Add(order);
              //  continue;
           // }

            //Product product = _cakeService.Bake(order);
            //products.Add(product);
       // }
            
        //var transportProvider = new TransportProvider();

        Transport transport = _transportService.CheckForAvailability(products);
        _transportService.Deliver(products);

        if (transport == Transport.Van)
        {
            //var van = new Van();
            _transportService.Deliver(products);
        }

        if (transport == Transport.Truck)
        {
            //var truck = new Truck();
            _transportService.Deliver(products);
        }

        if (transport == Transport.Ship)
        {
            //var ship = new Ship();
            _transportService.Deliver(products);
        }
    }
}
