using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CyberSolar.MODEL.Model;
using System.Web.Mvc;

namespace CyberSolar.Models
{
    public class PurchaseViewModel
    {
	    public int Id { set; get; }
        public string Code { set; get; }
        public DateTime PurchaseDate { set; get; }
        public string InvoiceNo { set; get; }
        public int SupplierId { set; get; }
        public Supplier Supplier { set; get; } //foreign key
        public PurchasedProductInformation PurchasedProduct { set; get; }

        public double TotalPrice { set; get; }
        public double PreviousUnitPrice { set; get; }
        public double PreviousMrp { set; get; }

        public List<PurchaseInformation> PurchaseInformations { set; get; }
        public List<SelectListItem> SupplierSelectListItems { set; get; }
        public List<SelectListItem> CategorySelectListItems { set; get; }
        public List<SelectListItem> ProductsSelectListItems { set; get; }
    }
}