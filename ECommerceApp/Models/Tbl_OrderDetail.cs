using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerceApp.Models
{
    public class Tbl_OrderDetail
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public DateTime? CreateDate { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public int UnitPrice { get; set; }

        public int Discount { get; set; }

        public int SubTotal { get; set; }

        public string Status { get; set; }

    }
}
