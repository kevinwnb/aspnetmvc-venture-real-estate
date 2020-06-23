using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MockUp.Controllers
{
    public class CreateCustomerController : Controller
    {
        // GET: CreateCustomer
        public ActionResult Index()
        {
            return View();
        }
    }
}