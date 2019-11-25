using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CyberSolar.MODEL.Model;

namespace CyberSolar.Models
{
    public class SupplierViewModel
    {
        public int Id { get; set; }

        [MinLength(4, ErrorMessage = "4 Characters required!")]
        [MaxLength(4, ErrorMessage = "4 Characters required!")]
        [Required(ErrorMessage = "required!!")]
        public string Code { get; set; }

        [Required(ErrorMessage = "required!!")]
        public string Name { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "required!!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "required!!")]
        public string Contact { get; set; }

        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }

        public List<Supplier> Suppliers { set; get; }

        public string SharedViewLayout = "~/Views/_Shared/_Layout.cshtml";
        public string SharedViewString = "~/Views/_Shared/Product/_SupplierDetails.cshtml";
    }
}