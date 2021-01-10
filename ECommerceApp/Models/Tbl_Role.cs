using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceApp.Models
{
    public class Tbl_Role
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string RoleName { get; set; }
    }
}