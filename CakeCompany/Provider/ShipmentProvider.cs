using System.Diagnostics;
using CakeCompany.Models;
using CakeCompany.Models.Transports;
using CakeCompany.Service;
using Serilog;

namespace CakeCompany.Provider;

internal class ShipmentProvider : IShipmentService
{
    private readonly ITransportService _transportService;
    private readonly ICakeService _cakeService;

    public ShipmentProvider(ITransportService transportService,
        ICakeService cakeService) {
        _transportService = transportService;
        _cakeService = cakeService;
    }

    public void GetShipment()
    {
        try {
            List<Product> products = _cakeService.GetProducts();

            Transport transport = _transportService.CheckForAvailability(products);

            DeliverProducts(transport, products);
        }
        catch (Exception e) {
            Log.Error(e.ToString());
        }
       
    }

    public void DeliverProducts(Transport transport,List<Product> products) {

        switch (transport) {

            case Transport.Van:
                Van van = new Van();
                van.Deliver(products);
                break;

            case Transport.Truck:
                Truck truck = new Truck();
                truck.Deliver(products);
                break;

            case Transport.Ship:
                Ship ship = new Ship();
                ship.Deliver(products);
                break;

            default:
                return;
        }
    }
}
