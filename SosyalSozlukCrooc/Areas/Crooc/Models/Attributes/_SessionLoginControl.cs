using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace SosyalSozlukCrooc.Areas.Crooc.Models.Attributes
{
    public class _SessionLoginControl : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (!HttpContext.Current.Response.IsRequestBeingRedirected)
                {
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary {
                        {"Controller","Home" },
                        {"action","Index" }
                    });
                    
                }


            }
        }
    }
}