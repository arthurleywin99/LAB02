using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB02_03.Model;

namespace LAB02_03.Controller
{
    public class GetCustomerController
    {
        public static List<Customer> GetCustomer()
        {
            using (var context = new TSContext())
            {
                return context.Customers.ToList();
            }
        }
    }
}
