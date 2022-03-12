using midproject.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace midproject.Controllers
{
    public class DetailsController : Controller
    {
        // GET: Details
        public ActionResult Index()
        {
            bdatabaseEntities db = new bdatabaseEntities();
            var data = (from d in db.billDetails where d.id == 1 select d).FirstOrDefault();
            return View(data);
        }
    }
}