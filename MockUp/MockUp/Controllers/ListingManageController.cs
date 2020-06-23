using MockUp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MockUp.Controllers
{
    public class ListingManageController : Controller
    {
        // GET: ListingManage
        public ActionResult Index()
        {
            VentureContext db = new VentureContext();
            List<Listing> listings = db.Listings.ToList();
            foreach (Listing listing in listings)
            {
                listing.ImgPath = db.Images.Where(i => i.ListingId == listing.ListingId)
                    .FirstOrDefault().Path;
            }
            return View(listings);
        }

        public ActionResult Create()
        {
            VentureContext db = new VentureContext();
            ViewBag.AgentSelect = new SelectList(db.Agents, "AgentId", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Listing listing, HttpPostedFileBase[] files)
        {
            VentureContext db = new VentureContext();
            
            if (ModelState.IsValid)
            {
                listing.AgentId = Convert.ToInt32(Request.Form["AgentSelect"]);
                db.Listings.Add(listing);
                db.SaveChanges();


                foreach (HttpPostedFileBase fileBase in files)
                {
                    if (!string.Equals(fileBase.ContentType, "image/jpg", StringComparison.OrdinalIgnoreCase) &&
                        !string.Equals(fileBase.ContentType, "image/jpeg", StringComparison.OrdinalIgnoreCase) &&
                        !string.Equals(fileBase.ContentType, "image/pjpeg", StringComparison.OrdinalIgnoreCase) &&
                        !string.Equals(fileBase.ContentType, "image/gif", StringComparison.OrdinalIgnoreCase) &&
                        !string.Equals(fileBase.ContentType, "image/x-png", StringComparison.OrdinalIgnoreCase) &&
                        !string.Equals(fileBase.ContentType, "image/png", StringComparison.OrdinalIgnoreCase))
                    {
                        ViewBag.Error = "The file is not an image";
                        return View();
                    }
                    else
                    {
                        string path = Path.Combine(Server.MapPath("~\\Uploads"),
                                               Path.GetFileName(fileBase.FileName));
                        fileBase.SaveAs(path);
                        Image img = new Image()
                        {
                            Approved = true,
                            ListingId = listing.ListingId,
                            Name = Path.GetFileName(path),
                            Path = Path.Combine("..\\..\\Uploads", Path.GetFileName(path))
                        };
                        db.Images.Add(img);
                        db.SaveChanges();
                        ViewBag.Message = "File uploaded successfully";
                    }
                }

                return RedirectToAction("Index", "ListingManage");
            }

            ViewBag.AgentSelect = new SelectList(db.Agents, "AgentId", "FullName");
            return View(listing);
        }
    }
}