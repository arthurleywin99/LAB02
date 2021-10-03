using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB02_03.Model;

namespace LAB02_03.Controller
{
    public class BillDetailsController
    {
        public static void AddBillDetails(BillDetail billDetail)
        {
            using (var context = new TSContext())
            {
                context.BillDetails.Add(billDetail);
                context.SaveChanges();
            }
        }
    }
}
