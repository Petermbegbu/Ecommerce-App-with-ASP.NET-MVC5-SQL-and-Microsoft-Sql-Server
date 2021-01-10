using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerceApp.Models
{
    public class Tbl_MemberRole
    {
        public int Id { get; set; }

        public Tbl_Member Tbl_Member { get; set; }

        [ForeignKey("Tbl_Member")]
        public int MemberId { get; set; }

        public Tbl_Role Tbl_Role { get; set; }

        [ForeignKey("Tbl_Role")]
        public int RoleId { get; set; }
    }
}