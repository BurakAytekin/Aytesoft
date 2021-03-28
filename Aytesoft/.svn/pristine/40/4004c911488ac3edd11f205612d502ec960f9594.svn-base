using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aytesoft.Models;
using System.Web.Security;

namespace Aytesoft.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        aytesoft_mvcEntities db = new aytesoft_mvcEntities();
        public ActionResult Index()
        {
            ViewBag.Kullanici = db.customers.Where(x => x.Id == User.Identity.Name).Select(x => x.Name).First();
            return View(db.Products.ToList());
        }
    }
}