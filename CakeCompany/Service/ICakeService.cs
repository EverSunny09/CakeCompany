using CakeCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeCompany.Service
{
    interface ICakeService
    {
        DateTime Check(Order order);

        Product Bake(Order order);

        List<Product> GetProducts();

    }
}
