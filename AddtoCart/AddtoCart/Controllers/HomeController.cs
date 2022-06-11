using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AddtoCart.Models;
namespace AddtoCart.Controllers
{
    public class HomeController : Controller
    {
        shoppingdbEntities db = new shoppingdbEntities();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.s = db.tbproducts.ToList();
            return View(ViewBag.s);
        }

        public ActionResult CategoryPage(int id)
        {
            var getc = db.tbproducts.Where(x => x.pcategory == id).ToList();
            
            return View(getc);
        }

        public ActionResult BrandPage(int id)
        {
            var getb = db.tbproducts.Where(x => x.pbrand == id).ToList();
           
            return View(getb);
        }

        public ActionResult CategoryDetail(int id)
        {
            var c = db.tbproducts.Where(x=>x.id==id).ToList();
            return View(c);
        }
    }
}