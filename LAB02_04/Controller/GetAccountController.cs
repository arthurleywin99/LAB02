using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB02_04.Model;

namespace LAB02_04.Controller
{
    internal class GetAccountController
    {
        public static List<Account> GetAccounts()
        {
            using (var context = new AMContext())
            {
                return context.Accounts.ToList();
            }
        }
    }
}
