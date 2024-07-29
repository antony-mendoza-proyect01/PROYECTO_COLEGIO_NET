using PROYECTO_FINAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PROYECTO_FINAL.permisos;

namespace PROYECTO_FINAL.Controllers
{
    public class HomeController : Controller
    {
        [ValidarSesionAtribute]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //Cerrar Sesion
        public ActionResult CerrarSesion()
        {
            Session["usuario"] = null;
            return RedirectToAction("Login", "Acceso");

        }
      
    }
}