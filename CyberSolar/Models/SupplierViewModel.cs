using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CyberSolar.MODEL.Model;

namespace CyberSolar.Models
{
    public class SupplierViewModel
    {
        public int Id { get; set; }

        [StringLength(4, MinimumLength = 4, ErrorMessage = "field must be 4 characters")]
        [Remote("IsCodeExists", "Supplier", ErrorMessage = "This code already in use")]
        [Required(ErrorMessage = "required!!")]
        public string Code { get; set; }

        [Required(ErrorMessage = "required!!")]
        public string Name { get; set; }

        public string Address { get; set; }

        [Remote("IsEmailExists", "Supplier", ErrorMessage = "This email already in use")]
        [Required(ErrorMessage = "required!!")]
        public string Email { get; set; }

        [MinLength(11, ErrorMessage = "field must be 11 characters")]
        [MaxLength(11, ErrorMessage = "field must be 11 characters")]
        [Range(0, Int64.MaxValue, ErrorMessage = "Numeric value required")]
        [Remote("IsContactExists", "Supplier", ErrorMessage = "This number already in use")]
        [Required(ErrorMessage = "required!!")]
        public string Contact { get; set; }

        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }

        public List<Supplier> Suppliers { set; get; }

        public string SharedViewLayout = "~/Views/_Shared/_Layout.cshtml";
        public string SharedViewString = "~/Views/_Shared/Supplier/_SupplierDetails.cshtml";

        public string SearchText { set; get; }
    }
}