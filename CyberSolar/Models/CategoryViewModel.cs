﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CyberSolar.MODEL.Model;

namespace CyberSolar.Models
{
    public class CategoryViewModel
    {
        public int Id { set; get; }

        [Remote("IsCodeExists", "Category", ErrorMessage = "This Code already in use")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "field must be 4 characters")]
        [Required(ErrorMessage = "required!!")]
        public string Code { set; get; }

        [Remote("IsNameExists", "Category", ErrorMessage = "This Name already in use")]
        [Required(ErrorMessage = "Name required!!")]
        [Display(Name = "Category Name")]
        public string Name { set; get; }

        public List<Category> Categories { set; get; }

        public string SearchText { set; get; }

        public string SharedViewLayout = "~/Views/_Shared/_Layout.cshtml";
        public string SharedViewString = "~/Views/_Shared/Category/_CategoryDetails.cshtml";
    }
}