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

        public static List<BillDetail> GetBillDetails(int ID)
        {
            using (var context = new TSContext())
            {
                return (from c in context.BillDetails
                        where c.BillID == ID
                        select c).ToList();
            }
        }

        public static int GetPrice(int SeatID)
        {
            using (var context = new TSContext())
            {
                int rowSeatID = Convert.ToInt32(context.Seats.Where(p => p.SeatID == SeatID).FirstOrDefault().RowSeatID);
                return Convert.ToInt32(context.RowSeats.Where(p => p.RowSeatID == rowSeatID).FirstOrDefault().Price);
            }
        }

        public static List<BillDetail> OrderedSeat()
        {
            using (var context = new TSContext())
            {
                return (from c in context.BillDetails
                        select c).ToList();
            }
        }
    }
}
