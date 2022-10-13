using CakeCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeCompany.Service
{
    interface ITransportService
    {
        Transport CheckForAvailability(List<Product> products);

        bool Deliver(List<Product> products);
    }
}
