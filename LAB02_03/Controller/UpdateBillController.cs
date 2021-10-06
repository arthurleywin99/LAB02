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
        public static bool AddBill(Bill bill, out string error)
        {
            using (var context = new TSContext())
            {
                error = string.Empty;
                try
                {
                    context.Bills.Add(bill);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return false;
                }
            }
        }

        public static bool AddBillDetails(BillDetail billDetail, out string error)
        {
            using (var context = new TSContext())
            {
                error = string.Empty;
                try
                {
                    context.BillDetails.Add(billDetail);
                    context.SaveChanges();
                    return true;    
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return false;
                }
            }
        }
    }
}
