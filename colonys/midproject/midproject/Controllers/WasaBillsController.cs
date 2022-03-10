using midproject.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace midproject.Controllers
{
    public class WasaBillsController : Controller
    {
        // GET: WasaBills
        public ActionResult Index()
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = db.wasaBills.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = (from b in db.wasaBills
                        where b.flatNumber == id
                        select b).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(wasaBill new_Edit)
        {
            if (ModelState.IsValid)
            {
                bdatabaseEntities db = new bdatabaseEntities();
                var data = (from b in db.wasaBills
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
            var data = (from b in db.wasaBills
                        where b.flatNumber == id
                        select b).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(wasaBill new_delete)
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = (from b in db.wasaBills
                        where b.flatNumber == new_delete.flatNumber
                        select b).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(new_delete);
            db.wasaBills.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}