using MockUp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VentureRealEstateMockUp.Controllers
{
    public class ListingController : Controller
    {
        // GET: listing
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
    }
}