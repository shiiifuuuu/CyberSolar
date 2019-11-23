using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CyberSolar.BLL.Manager;
using CyberSolar.Models;
using CyberSolar.MODEL.Model;

namespace CyberSolar.Controllers
{
    public class SupplierController : Controller
    {
        SupplierManager _supplierManager = new SupplierManager();
        Supplier _supplier = new Supplier();

        [HttpGet]
        public ActionResult Add()
        {
            SupplierViewModel supplierViewModel = new SupplierViewModel();
            supplierViewModel.Suppliers = _supplierManager.GetAll();
            return View(supplierViewModel);
        }

        [HttpPost]
        public ActionResult Add(SupplierViewModel supplierViewModel)
        {
            //default method
            //Category category = new Category();
            //category.Code = categoryViewModel.Code;
            //category.Name = categoryViewModel.Name;

            //automapper method
            Supplier supplier = Mapper.Map<Supplier>(supplierViewModel);

            string message = "";

            if (ModelState.IsValid)
            {
                if (_supplierManager.Add(supplier))
                {
                    message += "Saved!";
                }
                else
                {
                    message += "Not Saved!!";
                }
            }
            supplierViewModel.Suppliers = _supplierManager.GetAll();
            ViewBag.Message = message;
            return View(supplierViewModel);
        }
    }
}