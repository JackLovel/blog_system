using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlogSystem.MVCSite.Filter
{
    public class BlogSystemAuthAttribute:AuthorizeAttribute
    {
        public bool IsSkip { get; set; } = false;
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!(filterContext.HttpContext.Session["loginName"] != null ||
                filterContext.HttpContext.Request.Cookies["loginName"] != null)) 
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary()
                {
                    { "controller", "Home"},
                    { "action", "Login"}
                });
            }
        } 
    }
}