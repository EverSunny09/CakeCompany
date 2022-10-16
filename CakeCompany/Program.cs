// See https://aka.ms/new-console-template for more information

using CakeCompany.Provider;
using CakeCompany.Service;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Runtime.CompilerServices;


public class Program {
   
    public static void Main(string[] args) {

      Log.Logger = new LoggerConfiguration()
     .MinimumLevel.Debug()
     .WriteTo.Console()
        .CreateLogger();

        ServiceProvider serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddTransient<IShipmentService, ShipmentProvider>()
                .AddTransient<IOrderService, OrderProvider>()
                .AddTransient<ICakeService, CakeProvider>()
                .AddTransient<ITransportService, TransportProvider>()
                .AddTransient<IPaymentService, PaymentProvider>()
                .BuildServiceProvider();

        IShipmentService shipmentService = serviceProvider.GetService<IShipmentService>();
        if(shipmentService!=null)
            shipmentService.GetShipment();



        Console.WriteLine("Shipment Details...");
        Console.ReadLine();
        Log.CloseAndFlush();

    }
}

