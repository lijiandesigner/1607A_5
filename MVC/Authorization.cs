using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC
{
    public class Authorization:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if(filterContext.HttpContext.Session["UserName"]==null)
            {
                filterContext.HttpContext.Response.Redirect("/Login/Index");
            }
        }
    }
}