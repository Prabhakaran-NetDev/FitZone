using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitZone.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserRole"] == null)
            {
                return View();
            }
            else if (Session["UserRole"].ToString() == "admin")
            {
                return RedirectToAction("../Users/Index");
            }
            else if (Session["UserRole"].ToString() == "manager")
            {
                return RedirectToAction("../Users/Index");
            }
            else if (Session["UserRole"].ToString() == "staff")
            {
                return RedirectToAction("../Users/Index");
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Detailed description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Detailed contact page.";

            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}