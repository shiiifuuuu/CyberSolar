using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSolar.MODEL.Model
{
    public class PurchaseInformation
    {
	    public PurchaseInformation()
	    {
            PurchasedProduct = new PurchasedProductInformation();
	    }
        public int Id { set; get; }
        public string Code { set; get; }
        public DateTime PurchaseDate { set; get; }
        public string InvoiceNo { set; get; }
        public int SupplierId { set; get; }
        public Supplier Supplier { set; get; } //foreign key

        public PurchasedProductInformation PurchasedProduct { set; get; }
    }
}
