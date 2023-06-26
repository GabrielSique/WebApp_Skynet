using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seminario.Models.Permisos
{
    public class ValidarSesionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["email"] == null)
            {

                filterContext.Result = new RedirectResult("~/acceso/login");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}