namespace LAB02_03.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RowSeat")]
    public partial class RowSeat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RowSeat()
        {
            Seats = new HashSet<Seat>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RowSeatID { get; set; }

        public decimal? Price { get; set; }

        [StringLength(10)]
        public string RowSeatName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
