using midproject.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace midproject.Controllers
{
    public class FlatNumbersController : Controller
    {
        // GET: FlatNumbers
        public ActionResult Index()
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = db.flatNumbers.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = (from b in db.flatNumbers
                        where b.flatNumber1 == id
                        select b).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(flatNumber new_Edit)
        {
            if (ModelState.IsValid)
            {
                bdatabaseEntities db = new bdatabaseEntities();
                var data = (from b in db.flatNumbers
                            where b.flatNumber1 == new_Edit.flatNumber1
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
            var data = (from b in db.flatNumbers
                        where b.flatNumber1 == id
                        select b).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(flatNumber new_delete)
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = (from b in db.flatNumbers
                        where b.flatNumber1 == new_delete.flatNumber1
                        select b).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(new_delete);
            db.flatNumbers.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}