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

        [HttpGet]
        public ActionResult Search()
        {
            SupplierViewModel supplierViewModel = new SupplierViewModel();
            supplierViewModel.Suppliers = _supplierManager.GetAll();


            return View(supplierViewModel);
        }

        [HttpPost]
        public ActionResult Search(string searchText)
        {
            var suppliers = _supplierManager.GetAll();

            if (searchText != null)
            {
                suppliers = suppliers.Where(c => 
                c.Name.ToLower().Contains(searchText.ToLower()) 
                || c.Contact.ToLower().Contains(searchText.ToLower())
                || c.Email.ToLower().Contains(searchText.ToLower())
                )
                .ToList();
                //categories = categories.Where(c => c.Name.ToLower().Contains(searchText.ToLower())).ToList();
            }

            SupplierViewModel supplierViewModel = new SupplierViewModel();
            supplierViewModel.Suppliers = suppliers;

            return View(supplierViewModel);
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
                }
                else
                {
                    message = "Not Updated";
                }
            }
            else
            {
                message = "Model State False!!";
            }

            ViewBag.Message = message;
            supplierViewModel.Suppliers = _supplierManager.GetAll();

            return View(supplierViewModel);
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
                }
                else
                {
                    message = "Not Deleted";
                }
            }
            else
            {
                message = "Model State False!!";
            }

            ViewBag.Message = message;
            supplierViewModel.Suppliers = _supplierManager.GetAll();

            return View(supplierViewModel);
        }
    }
}