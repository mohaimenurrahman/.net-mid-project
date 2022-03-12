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
            var data = db.billDetails.ToList();
            return View(data);
        }
    }
}