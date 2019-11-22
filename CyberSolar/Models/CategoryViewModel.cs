using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CyberSolar.MODEL.Model;

namespace CyberSolar.Models
{
    public class CategoryViewModel
    {
        public int Id { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public List<Category> Categories { set; get; }
    }
}