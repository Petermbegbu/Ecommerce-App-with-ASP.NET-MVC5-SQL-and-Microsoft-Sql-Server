using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceApp.Models
{
    public class Tbl_Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string ProductName { get; set; }

        public Tbl_Category Category { get; set; }

        [Required]
        [Range(1,50)]
        [ForeignKey("Category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string Description { get; set; }

        public string ProductImage { get; set; }

        public bool IsFeatured { get; set; }

        [Required]
        [Range(typeof(int), "1", "500")]
        public int Quantity { get; set; }

        [Required]
        [Range(typeof(decimal), "1", "200000")]
        public decimal Price { get; set; }

        [NotMapped]
        public SelectList Categories { get; set; }
    }
}