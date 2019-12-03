using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CyberSolar.Controllers
{
    public class PurchaseController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {

            return View();
        }
    }
}