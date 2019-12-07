using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CyberSolar.BLL.Manager;
using CyberSolar.Models;
using CyberSolar.MODEL.Model;

namespace CyberSolar.Controllers
{
    public class PurchaseController : Controller
    {
        private PurchaseManager _purchaseManager;
        private CategoryManager _categoryManager;
        private SupplierManager _supplierManager;
        private ProductManager _productManager;

        public PurchaseController()
        {
            _purchaseManager = new PurchaseManager();
            _categoryManager = new CategoryManager();
            _supplierManager = new SupplierManager();
            _productManager = new ProductManager();
        }
        private void SuppliersDropDownLoad(PurchaseViewModel purchaseViewModel)
        {
            purchaseViewModel.SupplierSelectListItems = _supplierManager.GetAll()
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
        }
        private void CategoriesDropDownLoad(PurchaseViewModel purchaseViewModel)
        {
            purchaseViewModel.CategorySelectListItems = _categoryManager.GetAll()
                .Select(c => new SelectListItem()
                { Value = c.Id.ToString(), Text = c.Name }).ToList();
        }
        
        public JsonResult ProductsDropDownLoad(string categoryId)
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
            purchaseViewModel.ProductsSelectListItems = _productManager.GetAll()
                .Where(c=>c.CategoryId.Equals(categoryId))
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();

            return Json(purchaseViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Add()
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
            //_purchaseManager.GetAll();
            purchaseViewModel.PurchaseInformations = _purchaseManager.GetIQueryable().ToList(); //Get All Purchase Informations
            SuppliersDropDownLoad(purchaseViewModel);
            CategoriesDropDownLoad(purchaseViewModel);
            return View(purchaseViewModel);
        }
    }
}