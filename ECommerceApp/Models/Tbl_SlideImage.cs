using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceApp.Models
{
    public class Tbl_SlideImage
    {
        public int Id { get; set; }

        [StringLength(300)]
        public string SlideTitle { get; set; }

        public string Slideimage { get; set; }

    }
}