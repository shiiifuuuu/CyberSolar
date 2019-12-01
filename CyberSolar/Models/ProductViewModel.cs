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

        [Required(ErrorMessage = "Select a Category")]
        [Display(Name = "Category")]
        public int CategoryId { set; get; }
        public Category Category { set; get; } //Foreign Key Referrence

        [Remote("IsCodeExists", "Product", ErrorMessage = "This Code already in use")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "field must be 4 characters")]
        [Required(ErrorMessage = "required!!")]
        public string Code { set; get; }

        [Remote("IsNameExists", "Product", ErrorMessage = "This Name already in use")]
        [Required(ErrorMessage = "Required!!")]
        [Display(Name = "Product Name")]
        public string Name { set; get; }

        [Range(0, int.MaxValue, ErrorMessage = "numeric value required!")]
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
        public string SearchText { set; get; }
    }
}