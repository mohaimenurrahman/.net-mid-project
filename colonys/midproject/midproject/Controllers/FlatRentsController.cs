using midproject.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace midproject.Controllers
{
    public class FlatRentsController : Controller
    {
        // GET: FlatRents
        public ActionResult Index()
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = db.flatRents.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = (from b in db.flatRents
                        where b.flatNumber == id
                        select b).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(flatRent new_Edit)
        {
            if (ModelState.IsValid)
            {
                bdatabaseEntities db = new bdatabaseEntities();
                var data = (from b in db.flatRents
                            where b.flatNumber == new_Edit.flatNumber
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
            var data = (from b in db.flatRents
                        where b.flatNumber == id
                        select b).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(flatRent new_delete)
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = (from b in db.flatRents
                        where b.flatNumber == new_delete.flatNumber
                        select b).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(new_delete);
            db.flatRents.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}