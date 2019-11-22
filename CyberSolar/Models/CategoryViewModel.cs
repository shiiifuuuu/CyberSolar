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
        [MinLength(4, ErrorMessage = "4 characters required!")]
        public string Code { set; get; }

        [Required(ErrorMessage = "Name required!!")]
        [Display(Name = "Category Name")]
        public string Name { set; get; }

        public List<Category> Categories { set; get; }
    }
}