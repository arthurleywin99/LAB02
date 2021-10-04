namespace LAB02_04.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [StringLength(15)]
        public string AccountID { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public decimal? Total { get; set; }
    }
}
