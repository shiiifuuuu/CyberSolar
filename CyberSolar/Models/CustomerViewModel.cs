﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CyberSolar.MODEL.Model;

namespace CyberSolar.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [StringLength(4, MinimumLength = 4, ErrorMessage = "field must be 4 characters")]
        [Required(ErrorMessage = "required!!")]
        public string Code { get; set; }

        [Required(ErrorMessage = "required!!")]
        public string Name { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "required!!")]
        public string Email { get; set; }

        [MinLength(11, ErrorMessage = "field must be 11 characters")]
        [MaxLength(11,ErrorMessage = "field must be 11 characters")]
        [Range(0, int.MaxValue, ErrorMessage = "Numeric value required")]
        [Required(ErrorMessage = "required!!")]
        public string Contact { get; set; }

        public Double LoyaltyPoint { get; set; }

        public List<Customer> Customers { set; get; }

        public string SharedViewLayout = "~/Views/_Shared/_Layout.cshtml";
        public string SharedViewString = "~/Views/_Shared/Customer/_CustomerDetails.cshtml";
        public string SearchText { set; get; }
    }
}