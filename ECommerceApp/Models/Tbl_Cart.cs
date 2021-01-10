using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerceApp.Models
{
    public class Tbl_Cart
    {
        public int Id { get; set; }

        public Tbl_Product Tbl_Product { get; set; }

        [ForeignKey("Tbl_Product")]
        public int ProductId { get; set; }

        public Tbl_Member Tbl_Member { get; set; }
        
        [ForeignKey("Tbl_Member")]
        public int MemberId { get; set; }
    }
}