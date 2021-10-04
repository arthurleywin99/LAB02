using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB02_04.Model;

namespace LAB02_04.Controller
{
    internal class AccountController
    {
        public static void AddAccount(Account account)
        {
            using (var context = new AMContext())
            {
                context.Accounts.Add(account);
                context.SaveChanges();
            }
        }

        public static void UpdateAccount(string id, Account NewAccount)
        {
            using (var context = new AMContext())
            {
                var account =  context.Accounts.SingleOrDefault(p => p.AccountID == id);
                if (account != null)
                {
                    account.FullName = NewAccount.FullName;
                    account.Address = NewAccount.Address;
                    account.Total = NewAccount.Total;
                    context.SaveChanges();
                }
            }
        }

        public static void DeleteAccount(Account account)
        {
            using (var context = new AMContext())
            {
                context.Accounts.Attach(account);
                context.Accounts.Remove(account);
                context.SaveChanges();
            }
        }
    }
}
