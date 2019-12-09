using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CyberSolar.BLL.Manager;
using CyberSolar.Models;
using CyberSolar.MODEL.Model;
using AutoMapper;

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

        public JsonResult ProductsDropDownLoad(int categoryId)
        {
            var productList = _productManager.GetAll().Where(c => c.CategoryId == categoryId).ToList();
            var products = productList.Select(c => new { c.Id, c.Name }).ToList();

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductInfo(int productId)
        {
            var productList = _productManager.GetAll().Where(c => c.Id == productId).ToList();
            var productInfo = productList.Select(c=>new { c.Code, c.AvailableQuantity}).ToList();
            return Json(productInfo, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPreviousPurchaseInfo(int productId)
        {
	        var purchaseList = _purchaseManager.GetAll().Where(c => c.PurchasedProduct.ProductId == productId).ToList();
	        var purchaseInfo = purchaseList.Select(c => new {c.PurchasedProduct.UnitPrice, c.PurchasedProduct.Mrp}).ToList();
	        return Json(purchaseInfo, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Add()
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
            //_purchaseManager.GetAll();
            purchaseViewModel.PurchaseInformations = _purchaseManager.GetAll();
            SuppliersDropDownLoad(purchaseViewModel);
            CategoriesDropDownLoad(purchaseViewModel);
            //ProductsDropDownLoad(purchaseViewModel);
            return View(purchaseViewModel);
        }

        [HttpPost]
        public ActionResult Add(PurchaseViewModel purchaseViewModel)
        {
            PurchaseInformation aPurchase = Mapper.Map < PurchaseInformation > (purchaseViewModel);
            
            purchaseViewModel.PurchaseInformations = _purchaseManager.GetIQueryable().ToList(); //Get All Purchase Informations
            SuppliersDropDownLoad(purchaseViewModel);
            CategoriesDropDownLoad(purchaseViewModel);
            //ProductsDropDownLoad(purchaseViewModel);
            return View(purchaseViewModel);
        }
    }
}