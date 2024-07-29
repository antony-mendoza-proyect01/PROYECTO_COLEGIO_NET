using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROYECTO_FINAL.permisos
{
    //herencia 
    public class ValidarSesionAtribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //cada que no se inice sesion no redireccione
            if (HttpContext.Current.Session["usuario"] == null) {
                filterContext.Result = new RedirectResult("~/Acceso/Login");
            }
         
            base.OnActionExecuting(filterContext);
        }
    }
}