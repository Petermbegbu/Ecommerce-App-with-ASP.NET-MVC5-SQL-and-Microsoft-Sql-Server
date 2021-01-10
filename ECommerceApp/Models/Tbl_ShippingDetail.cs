using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerceApp.Models
{
    public class Tbl_ShippingDetail
    {
        public int Id { get; set; }

        public Tbl_Member Tbl_Member { get; set; }

        [Required]
        [ForeignKey("Tbl_Member")]
        public int MemberId { get; set; }

        [Required]
        [StringLength(300)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        public string State { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        [StringLength(50)]
        public string ZipCode { get; set; }

        public int OrderId { get; set; }

        public decimal AmountPaid { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentType { get; set; }

    }
}