using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aytesoft.Models;

namespace Aytesoft.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        aytesoft_mvcEntities db = new aytesoft_mvcEntities();
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Kullanici = db.customers.Where(x => x.Id == User.Identity.Name).Select(x => x.Name).First();
            return View(db.Products.ToList());
        }

        [HttpPost]
        public JsonResult AddBasket(int productId, int quantity)
        {
            string userid = User.Identity.Name;
            DateTime date = DateTime.Now.Date;
            Product pd = db.Products.Where(x => x.id == productId).FirstOrDefault();
            basket bt = new basket();
            bt.productid = productId;
            bt.customerid = userid;
            bt.quantity = quantity;
            bt.createdate = date;
            bt.productcode = pd.Code;
            bt.productname = pd.Name;
            bt.price = db.product_price.Where(x => x.productid == productId).Select(x => x.price).FirstOrDefault();
            db.baskets.Add(bt);
            var rt = db.SaveChanges();
            return Json(rt,JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult Basket()
        {
            List<basket> bt = db.baskets.Where(x => x.customerid == User.Identity.Name).ToList();
            ViewBag.Kullanici = db.customers.Where(x => x.Id == User.Identity.Name).Select(x => x.Name).First();
            return View(bt);
        }
        
        public void Remove(int productid, int quantity)
        {
            var basketitem = db.baskets.Where(x => x.id == productid).FirstOrDefault();
            db.baskets.Remove(basketitem);
            db.SaveChanges();
            Basket();
        }

        public void orderdetailadd(List<basket> bt, int orderno)
        {
            foreach (var item in bt)
            {
                double sub = Convert.ToDouble(item.price * item.quantity);
                double disc = sub * 0.1;
                double spwith = sub - disc;
                double total = spwith + spwith * 0.18;
                order_detail od = new order_detail();
                od.customerid = User.Identity.Name;
                od.date = DateTime.Now.Date.ToShortDateString();
                od.discount = disc;
                od.discountrate = 10;
                od.orderno = orderno;
                od.productcode = item.productcode;
                od.productname = item.productname;
                od.quantity = item.quantity;
                od.total = total;
                od.price = item.price;
                db.order_detail.Add(od);
                db.baskets.Remove(item);
            }
            db.SaveChanges();
        }
        public ActionResult PlaceOrder()
        {
            double totalprice = 0;
            int totalquantity = 0;
            string products = "";
            List<basket> bt = db.baskets.Where(x => x.customerid == User.Identity.Name).ToList();
            foreach(var item in bt)
            {
                double subprice = Convert.ToDouble(item.price * item.quantity);
                double discount = subprice * 0.1;
                double spwithoutd = subprice - discount;
                totalprice += spwithoutd + spwithoutd * 0.18;
                totalquantity += Convert.ToInt32(item.quantity);
                products += "<"+item.productid + ">";
            }
            order o = new order();
            o.productid = products;
            o.totalquantity = totalquantity;
            o.totalprice = totalprice;
            o.customerid = User.Identity.Name;
            o.createdate = DateTime.Now.Date.ToShortDateString();
            db.orders.Add(o);
            db.SaveChanges();
            var date = DateTime.Now.Date.ToShortDateString();
            int orderno = db.orders.Where(x => x.createdate == date && x.customerid == User.Identity.Name && x.totalprice == totalprice).Select(x => x.no).FirstOrDefault();
            orderdetailadd(bt, orderno);
            return RedirectToAction("Index");
        }

    }
}