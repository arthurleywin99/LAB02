using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LAB02_04.Model
{
    public partial class AMContext : DbContext
    {
        public AMContext()
            : base("name=AMContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.AccountID)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Total)
                .HasPrecision(18, 0);
        }
    }
}
