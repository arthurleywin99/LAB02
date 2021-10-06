using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB02_03.Model;

namespace LAB02_03.Controller
{
    internal class UpdateBillController
    {
        public static void AddBill(Bill bill)
        {
            using (var context = new TSContext())
            {
                context.Bills.Add(bill);
                context.SaveChanges();
            }
        }

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
