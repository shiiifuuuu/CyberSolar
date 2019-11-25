using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CyberSolar.MODEL.Model;

namespace CyberSolar.Models
{
    public class CategoryViewModel
    {
        public int Id { set; get; }

        [Required(ErrorMessage = "Code required!!")]
        [MinLength(4, ErrorMessage = "4 characters required!"), MaxLength(4, ErrorMessage = "Must be 4 characters!")]
        public string Code { set; get; }

        [Required(ErrorMessage = "Name required!!")]
        [Display(Name = "Category Name")]
        public string Name { set; get; }

        public List<Category> Categories { set; get; }
        public string SearchText { set; get; }

        public string SharedViewLayout = "~/Views/_Shared/_Layout.cshtml";
        public string SharedViewString = "~/Views/_Shared/Product/_CategoryDetails.cshtml";
    }
}