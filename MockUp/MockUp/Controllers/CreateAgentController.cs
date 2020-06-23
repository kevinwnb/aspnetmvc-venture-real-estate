using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MockUp.Models;

namespace MockUp.Controllers
{
    public class CreateAgentController : Controller
    {
        // GET: CreateAgent
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "SIN, FirstName, MiddleName, LoggedInUserName, StreetAddress, Municipality, Province, PostalCode, HomePhoneNumber, CellPhoneNumber, OfficeEmail, OfficePhoneNumber, DateOfBirth")] Agent agent)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Pets.Add(pet);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.OwnerId = new SelectList(db.Owners, "ID", "OwnerFullName", pet.OwnerId);
            return View();
        }
    }
}