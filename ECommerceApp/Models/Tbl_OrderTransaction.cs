using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerceApp.Models
{
    public class Tbl_OrderTransaction
    {
        public int Id { get; set; }

        public Tbl_OrderDetail OrderDetail { get; set; }

        [ForeignKey("OrderDetail")]
        public int OrderDetailId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string PhoneNo { get; set; }

        public string Email { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? TotalItems { get; set; }

        public string DeliveryAddress { get; set; }

        public string DeliveryDay { get; set; }

        public string AdditionalOrderInfo { get; set; }

        public int? Discount { get; set; }

        public int? SubTotal { get; set; }

        public string Status { get; set; }

    }
}