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

        public ActionResult ColonyDetails()
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = db.colonys.ToList();
            return View(data);
        }

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


        public ActionResult BuildingDetails()
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
                return RedirectToAction("BuildingDetails");

            }
            return View(b);
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
                return RedirectToAction("BuildingDetails");
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
            return RedirectToAction("BuildingDetails");

        }

        public ActionResult request()
        {
            return View();
        }


    }
}