using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConcesionarioCutre.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Así somos nosotros.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Puedes (intentar) contactarnos.";

            return View();
        }
    }
}