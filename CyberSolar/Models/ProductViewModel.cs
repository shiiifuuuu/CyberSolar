using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CyberSolar.MODEL.Model;

namespace CyberSolar.Models
{
    public class ProductViewModel
    {
        public int Id { set; get; }

        [Display(Name = "Category")]
        public int CategoryId { set; get; }
        public Category Customer { set; get; } //Foreign Key Referrence


        [MinLength(4, ErrorMessage = "Must be 4 characters!"),MaxLength(4, ErrorMessage = "Must be 4 characters!")]
        [Required(ErrorMessage = "Required!")]
        public string Code { set; get; }

        [Required(ErrorMessage = "Required!!")]
        [Display(Name = "Product Name")]
        public string Name { set; get; }

        [Required(ErrorMessage = "Required!!")]
        [Display(Name = "Reorder Level")]
        public int ReorderLevel { set; get; }

        [Required(ErrorMessage = "Required!!")]
        public string Description { set; get; }

        public int AvailableQuantity { set; get; }

        public List<Product> Products { set; get; }
        public List<SelectListItem> CategorySelectListItems { set; get; }

        public string SharedViewLayout = "~/Views/_Shared/_Layout.cshtml";
        public string SharedViewString = "~/Views/_Shared/Product/_ProductDetails.cshtml";
    }
}