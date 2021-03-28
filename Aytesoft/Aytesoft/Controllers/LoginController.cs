using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aytesoft.Models;
using System.Web.Security;

namespace Aytesoft.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        aytesoft_mvcEntities db = new aytesoft_mvcEntities();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(Aytesoft.Models.customer cs)
        {
            Session.Abandon();
            
            var log = db.customers.Where(x => x.Id == cs.Id && x.Password == cs.Password).FirstOrDefault();
            Session["Username"] = cs.Name;
            if (log != null)
            {
                FormsAuthentication.RedirectFromLoginPage(log.Id, true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "Username or password isn't correct";
                return View("Index");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Index");
        }
    }
}