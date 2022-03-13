using billman.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace billman.Controllers
{
    public class employeeController : Controller
    {
        // GET: employee
       

        public ActionResult List()
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = db.employees.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            
            return View(new employee());
        }

        [HttpPost]
        public ActionResult Create(employee e)
        {
            if (ModelState.IsValid)
            {
                bdatabaseEntities db = new bdatabaseEntities();
                db.employees.Add(e);
                db.SaveChanges();

                return RedirectToAction("List");

            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var emp = (from e in db.employees
                      where e.empId == id
                      select e).FirstOrDefault();

            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(employee ee)
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var emp = (from e in db.employees
                       where e.empId == ee.empId
                       select e).FirstOrDefault();
            db.Entry(emp).CurrentValues.SetValues(ee);
            db.SaveChanges();
            return RedirectToAction("List");

        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var emp = (from e in db.employees
                       where e.empId == id
                       select e).FirstOrDefault();

            return View(emp);

        }

        [HttpPost]
        public ActionResult Delete(employee ee)
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var emp = (from e in db.employees
                       where e.empId == ee.empId
                       select e).FirstOrDefault();
            db.employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("List");
        }



        ///////////////////////// GET: subscriptions//////////////////////////////////////////

        public ActionResult subList()
        {
            bdatabaseEntities subdb = new bdatabaseEntities();
            var subdata = subdb.subscriptions.ToList();
            return View(subdata);
        }

        [HttpGet]
        public ActionResult subCreate()
        {
            return View(new subscription());
        }
        [HttpPost]
        public ActionResult subCreate(subscription s)
        {
            if (ModelState.IsValid)
            {
                bdatabaseEntities subdb = new bdatabaseEntities();
                subdb.subscriptions.Add(s);
                subdb.SaveChanges();

                return RedirectToAction("subList");

            }
            return View();
        }

        [HttpGet]
        public ActionResult subEdit(string id)
        {
            bdatabaseEntities subdb = new bdatabaseEntities();
            var sub = (from s in subdb.subscriptions
                       where s.username == id
                       select s).FirstOrDefault();

            return View(sub);
        }
        [HttpPost]
        public ActionResult subEdit(subscription ss)
        {
            bdatabaseEntities subdb = new bdatabaseEntities();
            var sub = (from s in subdb.subscriptions
                       where s.username == ss.username
                       select s).FirstOrDefault();
            subdb.Entry(sub).CurrentValues.SetValues(ss);
            subdb.SaveChanges();
            return RedirectToAction("subList");

        }

        [HttpGet]
        public ActionResult subDelete(string id)
        {
            bdatabaseEntities subdb = new bdatabaseEntities();
            var sub = (from s in subdb.subscriptions
                       where s.username == id
                       select s).FirstOrDefault();

            return View(sub);
        }

        [HttpPost]
        public ActionResult subDelete(subscription ss)
        {
            bdatabaseEntities subdb = new bdatabaseEntities();
            var sub = (from s in subdb.subscriptions
                       where s.username == ss.username
                       select s).FirstOrDefault();
            subdb.subscriptions.Remove(sub);
            subdb.SaveChanges();
            return RedirectToAction("subList");
        }

        ///////////////////////// GET: subUsers//////////////////////////////////////////
        public ActionResult userList()
        {
            bdatabaseEntities usdb = new bdatabaseEntities();
            var usdata = usdb.subUsers.ToList();
            return View(usdata);
        }

        [HttpGet]
        public ActionResult userCreate()
        {
            return View(new subUser());
        }

        [HttpPost]
        public ActionResult userCreate(subUser u)
        {
            if (ModelState.IsValid)
            {
                bdatabaseEntities usdb = new bdatabaseEntities();
                usdb.subUsers.Add(u);
                usdb.SaveChanges();

                return RedirectToAction("userList");

            }
            return View();

        }

        [HttpGet]
        public ActionResult userEdit(string id)
        {
            bdatabaseEntities usdb = new bdatabaseEntities();
            var user = (from u in usdb.subUsers
                       where u.flatNumber == id
                       select u).FirstOrDefault();

            return View(user);
        }

        [HttpPost]
        public ActionResult userEdit(subUser uu)
        {
            bdatabaseEntities usdb = new bdatabaseEntities();
            var user = (from u in usdb.subUsers
                       where u.flatNumber == uu.flatNumber
                       select u).FirstOrDefault();
            usdb.Entry(user).CurrentValues.SetValues(uu);
            usdb.SaveChanges();
            return RedirectToAction("userList");
        }
        [HttpGet]
        public ActionResult userDelete(string id)
        {
            bdatabaseEntities usdb = new bdatabaseEntities();
            var user = (from u in usdb.subUsers
                        where u.flatNumber == id
                        select u).FirstOrDefault();

            return View(user);
        }

        [HttpPost]
        public ActionResult userDelete(subUser uu)
        {
            bdatabaseEntities usdb = new bdatabaseEntities();
            var user = (from u in usdb.subUsers
                        where u.flatNumber == uu.flatNumber
                        select u).FirstOrDefault();
            usdb.subUsers.Remove(user);
            usdb.SaveChanges();
            return RedirectToAction("userList");
        }

    }

}