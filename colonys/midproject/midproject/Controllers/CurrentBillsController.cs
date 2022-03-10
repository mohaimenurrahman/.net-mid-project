using midproject.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace midproject.Controllers
{
    public class CurrentBillsController : Controller
    {
        // GET: CurrentBills
        public ActionResult Index()
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = db.currentBills.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = (from b in db.currentBills
                        where b.flatNumber == id
                        select b).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(currentBill new_Edit)
        {
            if (ModelState.IsValid)
            {
                bdatabaseEntities db = new bdatabaseEntities();
                var data = (from b in db.currentBills
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
            var data = (from b in db.currentBills
                        where b.flatNumber == id
                        select b).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(currentBill new_delete)
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = (from b in db.currentBills
                        where b.flatNumber == new_delete.flatNumber
                        select b).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(new_delete);
            db.currentBills.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}