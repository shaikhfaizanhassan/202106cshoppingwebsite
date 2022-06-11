using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AddtoCart.Models;
namespace AddtoCart.Controllers
{
    public class AdminController : Controller
    {
        shoppingdbEntities db = new shoppingdbEntities();
        // GET: Admin
        public ActionResult Index()
        {
            try
            {
                Response.Cache.SetNoStore();
                if(Session["adminID"].ToString()!="")
                {
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.s = ex.ToString();
            }
            return View();
           
        }
        [HttpPost]
        public ActionResult Index(admin ad)
        {
            try
            {
                var login = db.admins.Where(l => l.username == ad.username && l.passwords == ad.passwords).SingleOrDefault();
                if(login!=null)
                {
                    Session["adminID"] = login.id.ToString();
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.s = ex.ToString();
                return RedirectToAction("Index");

            }
           
        }

        public ActionResult Dashboard()
        {
            try
            {
                Response.Cache.SetNoStore();
                ViewBag.id = Session["adminID"].ToString();
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.s = ex.ToString();
                return RedirectToAction("Index");
            }
            
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }

        public ActionResult AddCat()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCat(tbcat tc)
        {
            if (ModelState.IsValid)
            {
                db.tbcats.Add(tc);
                db.SaveChanges();
                ViewBag.msg = "Cat Has Been Save";   
            }   
            return View();
        }
        public ActionResult ViewCat()
        {
            ViewBag.l = db.tbcats.ToList();
            return PartialView(ViewBag.l);
        }

        public ActionResult Addbrand()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Addbrand(tbbrand tb)
        {
            if (ModelState.IsValid)
            {
                db.tbbrands.Add(tb);
                db.SaveChanges();
                ViewBag.msg = "Brand Has Been Save";
            }
            return View();
        }

        public ActionResult Viewbrand()
        {
            ViewBag.b = db.tbbrands.ToList();
            return PartialView(ViewBag.b);
        }

        public ActionResult AddProduct()
        {
            ViewBag.showCat = new SelectList(db.tbcats, "id", "c_name");
            ViewBag.showbrand = new SelectList(db.tbbrands, "id", "b_name");

            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(tbproduct tp, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if(file!=null)
                {
                    string imagename = System.IO.Path.GetFileName(file.FileName);
                    string physicalpath = Server.MapPath("~/ProductImage/" + imagename);
                    file.SaveAs(physicalpath);
                    db.tbproducts.Add(tp);
                    tp.pEntry = DateTime.Now;
                    tp.pimage = imagename;
                    db.SaveChanges();
                    ViewBag.msg = "Product Has Been Save";
                }

              
            }
            return View();
        }

        public ActionResult ViewProduct()
        {
            ViewBag.p = db.tbproducts.ToList();
            return PartialView(ViewBag.p);
        }

    }
}