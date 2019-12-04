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

        [HttpGet]
        public ActionResult Add()
        {
            SupplierViewModel supplierViewModel = new SupplierViewModel();
            supplierViewModel.Suppliers = _supplierManager.GetAll();

            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            return View(supplierViewModel);
        }

        [HttpPost]
        public ActionResult Add(SupplierViewModel supplierViewModel)
        {
            Supplier supplier = Mapper.Map<Supplier>(supplierViewModel);
            supplier.Code = supplier.Code.ToUpper();

            string message = "";

            if (ModelState.IsValid)
            {
                if (_supplierManager.Add(supplier))
                {
                    message = "Saved!";
                    ModelState.Clear();
                }
                else
                {
                    message = "Not Saved!!";
                }
            }

            ViewBag.Message = message;
            SupplierViewModel emptyModel = new SupplierViewModel() { Suppliers = _supplierManager.GetAll() };
            
            return View(emptyModel);
        }

        //[HttpGet]
        //public ActionResult Search()
        //{
        //    SupplierViewModel supplierViewModel = new SupplierViewModel();
        //    supplierViewModel.Suppliers = _supplierManager.GetAll();


        //    return View(supplierViewModel);
        //}

        [HttpPost]
        public ActionResult Search(SupplierViewModel supplierViewModel)
        {
            string searchText = supplierViewModel.SearchText;
            string message = "";
            var suppliers = _supplierManager.GetAll();

            if (searchText != null)
            {
                suppliers = suppliers.Where(c => 
                c.Name.ToLower().Contains(searchText.ToLower()) 
                || c.Contact.ToLower().Contains(searchText.ToLower())
                || c.Email.ToLower().Contains(searchText.ToLower())
                )
                .ToList();

                message = suppliers.Count + " result found";
                //categories = categories.Where(c => c.Name.ToLower().Contains(searchText.ToLower())).ToList();
            }
            ViewBag.Message = message;
            SupplierViewModel resultModel = new SupplierViewModel() { Suppliers = suppliers};

            return View(resultModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var supplier = _supplierManager.GetById(id);

            SupplierViewModel supplierViewModel = Mapper.Map<SupplierViewModel>(supplier);

            supplierViewModel.Suppliers = _supplierManager.GetAll();

            return View(supplierViewModel);
        }

        [HttpPost]
        public ActionResult Edit(SupplierViewModel supplierViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Supplier supplier = Mapper.Map<Supplier>(supplierViewModel);

                if (_supplierManager.Update(supplier))
                {
                    message = "Updated";
                    ModelState.Clear();
                    TempData["Message"] = message;
                    return RedirectToAction("Add", "Supplier");
                }
                else
                {
                    message = "Not Updated";
                }
            }

            ViewBag.Message = message;
            SupplierViewModel emptyModel = new SupplierViewModel() { Suppliers = _supplierManager.GetAll() };

            return View(emptyModel);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var supplier = _supplierManager.GetById(id);

            SupplierViewModel supplierViewModel = Mapper.Map<SupplierViewModel>(supplier);

            supplierViewModel.Suppliers = _supplierManager.GetAll();

            return View(supplierViewModel);
        }

        [HttpPost]
        public ActionResult Delete(SupplierViewModel supplierViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Supplier supplier = Mapper.Map<Supplier>(supplierViewModel);

                if (_supplierManager.Delete(supplier.Id))
                {
                    message = "Deleted";
                    ModelState.Clear();
                    return RedirectToAction("Add", "Supplier");
                }
                else
                {
                    message = "Not Deleted";
                }
            }

            ViewBag.Message = message;
            SupplierViewModel emptyModel = new SupplierViewModel() { Suppliers = _supplierManager.GetAll() };

            return View(supplierViewModel);
        }

        public JsonResult IsCodeExists(string code) {
            List<Supplier> suppliers = _supplierManager.GetAll();
            JsonResult isUnique = Json(suppliers.All(c=>c.Code.ToLower()!=code.ToLower()), JsonRequestBehavior.AllowGet);
            return isUnique;
        }
        public JsonResult IsEmailExists(string email) {
            List<Supplier> suppliers = _supplierManager.GetAll();
            JsonResult isUnique = Json(suppliers.All(c => c.Email.ToLower() != email.ToLower()), JsonRequestBehavior.AllowGet);
            return isUnique;
        }
        public JsonResult IsContactExists(string contact) {
            List<Supplier> suppliers = _supplierManager.GetAll();
            JsonResult isUnique = Json(suppliers.All(c => c.Contact.ToLower() != contact.ToLower()), JsonRequestBehavior.AllowGet);
            return isUnique;
        }
    }
}