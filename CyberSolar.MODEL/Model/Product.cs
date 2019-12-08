using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSolar.MODEL.Model
{
    public class Product
    {
        public Product()
        {
            Category = new Category();
        }
        public int Id { set; get; }
        public int CategoryId { set; get; }
        [ForeignKey("CategoryId")]
        public Category Category { set; get; } //Foreign Key Referrence
        public string Code { set; get; }
        public string Name { set; get; }
        public int ReorderLevel { set; get; }
        public string Description { set; get; }
        public int AvailableQuantity { set; get; }
    }
}
