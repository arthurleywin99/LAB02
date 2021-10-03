namespace LAB02_03.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BillDetail")]
    public partial class BillDetail
    {
        public int BillDetailID { get; set; }

        public int? BillID { get; set; }

        public int? SeatID { get; set; }

        public virtual Bill Bill { get; set; }

        public virtual Seat Seat { get; set; }
    }
}
