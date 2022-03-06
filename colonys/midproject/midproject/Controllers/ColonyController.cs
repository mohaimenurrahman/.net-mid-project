using midproject.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace midproject.Controllers
{
    public class ColonyController : Controller
    {
        // GET: Colony
        public ActionResult Buildings()
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = db.buildings.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult AddBuildings()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBuildings(building c)
        {
            if(ModelState.IsValid)
            {
                bdatabaseEntities db = new bdatabaseEntities();
                db.buildings.Add(c);
                db.SaveChanges();
                return RedirectToAction("Buildings");

            }
            return View(c);
        }
    }
}