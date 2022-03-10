﻿using midproject.Models.Database;
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

        [HttpGet]
        public ActionResult Edit(string id)
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = (from b in db.buildings
                        where b.buildingCode == id
                        select b).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(building new_Edit)
        {
            if (ModelState.IsValid)
            {
                bdatabaseEntities db = new bdatabaseEntities();
                var data = (from b in db.buildings
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
            var data = (from b in db.buildings
                        where b.buildingCode == id
                        select b).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(building new_delete)
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = (from b in db.buildings
                        where b.buildingCode == new_delete.buildingCode
                        select b).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(new_delete);
            db.buildings.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}