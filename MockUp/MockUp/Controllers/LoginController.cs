using MockUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MockUp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Login login)
        {
            VentureContext db = new VentureContext();
            // Query for the Blog named ADO.NET Blog
            Login loginMatch = db.Logins
                            .Where(l => l.Username == login.Username && l.Password == login.Password)
                            .FirstOrDefault();
            if (loginMatch == null)
            {
                ViewBag.Error = "Username and/or Password incorrect. Try again.";
                return View();
            }

            Session.Add("username", loginMatch.Username);
            Session.Add("role", loginMatch.RoleId);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session["username"] = null;
            Session["role"] = null;

            return RedirectToAction("Index", "Home");
        }
    }
}