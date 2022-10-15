// See https://aka.ms/new-console-template for more information

using CakeCompany.Provider;
using CakeCompany.Service;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("CakeCompany.UnitTest")]


public class Program {
   
    public static void Main(string[] args) {
        Log.Logger = new LoggerConfiguration()
     .MinimumLevel.Debug()
     .WriteTo.Console()
     .CreateLogger();

        

        Console.WriteLine("Shipment Details...");
        Console.ReadLine();
        Log.CloseAndFlush();
    }
}

