using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB02_03.Model;

namespace LAB02_03.Controller
{
    internal class GetBillController
    {
        public static List<Bill> GetBill()
        {
            using (var context = new TSContext())
            {
                return context.Bills.ToList();
            }
        }
    }
}
