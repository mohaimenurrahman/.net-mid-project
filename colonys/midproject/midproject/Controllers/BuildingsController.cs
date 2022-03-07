using midproject.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace midproject.Controllers
{
    public class BuildingsController : Controller
    {
        // GET: Buildings
        public ActionResult Index()
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = db.buildingDetails.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(buildingDetail b)
        {
            if (ModelState.IsValid)
            {
                bdatabaseEntities db = new bdatabaseEntities();
                db.buildingDetails.Add(b);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(b);
        }
    }
}