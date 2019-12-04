using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSolar.MODEL.Model
{
    public class PurchasedProductInformation
    {
        public int Id { set; get; }
        public string ProductId { set; get; }
        public Product Product { set; get; }//foreign key
        public DateTime ManufacturedDate { set; get; }
        public DateTime ExpireDate { set; get; }
        public int Quantity { set; get; }
        public double UnitPrice { set; get; }
        public double Mrp { set; get; }
        public string Remarks { set; get; }
        public int PurchaseInformationId { set; get; }
        public PurchaseInformation PurchaseInformation { set; get; }//foreign key
    }
}
