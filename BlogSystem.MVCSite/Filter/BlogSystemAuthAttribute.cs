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
        //public bool IsSkip { get; set; } = false;
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // 当有户存储在 cookie 中且session数据为空时，把cookie的数据同步到session中
            if (filterContext.HttpContext.Request.Cookies["loginName"] != null &&
               filterContext.HttpContext.Session["loginName"] == null)
            {
                filterContext.HttpContext.Session["loginName"] = filterContext.HttpContext.Request.Cookies["loginName"];
                filterContext.HttpContext.Session["userid"] = filterContext.HttpContext.Request.Cookies["userid"];

            }

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