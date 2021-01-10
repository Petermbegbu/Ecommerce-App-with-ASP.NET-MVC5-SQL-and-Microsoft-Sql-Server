using ECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceApp.ViewModel
{
    public class RandomViewModel
    {
        public Tbl_Cart Tbl_Cart { get; set; }
        public List<Tbl_Cart> Tbl_Carts { get; set; }

        public Tbl_CartStatus Tbl_CartStatus { get; set; }
        public List<Tbl_CartStatus> Tbl_CartStatuses { get; set; }

        public Tbl_Category Tbl_Category { get; set; }
        public List<Tbl_Category> Tbl_Categories { get; set; }

        public Tbl_Member Tbl_Member { get; set; }
        public List<Tbl_Member> Tbl_Members { get; set; }

        public Tbl_MemberRole Tbl_MemberRole { get; set; }
        public List<Tbl_MemberRole> Tbl_MemberRoles { get; set; }

        public Tbl_Product Tbl_Product { get; set; }
        public List<Tbl_Product> Tbl_Products { get; set; }

        public Tbl_Role Tbl_Role { get; set; }
        public List<Tbl_Role> Tbl_Roles { get; set; }

        public Tbl_ShippingDetail Tbl_ShippingDetail { get; set; }
        public List<Tbl_ShippingDetail> Tbl_ShippingDetails { get; set; }

        public Tbl_SlideImage Tbl_SlideImage { get; set; }
        public List<Tbl_SlideImage> Tbl_SlideImages { get; set; }

        public Tbl_OrderTransaction Tbl_OrderTransaction { get; set; }
        public List<Tbl_OrderTransaction> Tbl_OrderTransactions { get; set; }

        public Tbl_OrderDetail Tbl_OrderDetail { get; set; }
        public List<Tbl_OrderDetail> Tbl_OrderDetails { get; set; }


        //Properties of Pagination and Sorting 
        public double HomeTotalPages { get; set; }

        public int HomePageNumber { get; set; }

        //Properties of Carts List 
        public int Quantity { get; set; }
    }
}