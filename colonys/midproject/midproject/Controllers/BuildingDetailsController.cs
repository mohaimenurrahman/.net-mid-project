using midproject.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace midproject.Controllers
{
    public class BuildingDetailsController : Controller
    {
        // GET: BuildingDetails
        public ActionResult Index()
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = db.buildingDetails.ToList();
            return View(data);
        }


        [HttpGet]
        public ActionResult Edit(string id)
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = (from b in db.buildingDetails
                        where b.buildingCode == id
                        select b).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(buildingDetail new_Edit)
        {
            if (ModelState.IsValid)
            {
                bdatabaseEntities db = new bdatabaseEntities();
                var data = (from b in db.buildingDetails
                            where b.buildingCode == new_Edit.buildingCode
                            select b).FirstOrDefault();
                db.Entry(data).CurrentValues.SetValues(new_Edit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = (from b in db.buildingDetails
                        where b.buildingCode == id
                        select b).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(buildingDetail new_delete)
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = (from b in db.buildingDetails
                        where b.buildingCode == new_delete.buildingCode
                        select b).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(new_delete);
            db.buildingDetails.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}