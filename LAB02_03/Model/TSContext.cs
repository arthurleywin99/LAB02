using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LAB02_03.Model
{
    public partial class TSContext : DbContext
    {
        public TSContext()
            : base("name=TSContext1")
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillDetail> BillDetails { get; set; }
        public virtual DbSet<RowSeat> RowSeats { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .Property(e => e.Total)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RowSeat>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RowSeat>()
                .Property(e => e.RowSeatName)
                .IsUnicode(false);
        }
    }
}
