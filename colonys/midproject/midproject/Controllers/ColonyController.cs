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
    }
}