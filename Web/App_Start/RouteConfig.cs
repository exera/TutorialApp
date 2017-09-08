using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "NewsList",
                url: "haberler/{page}",
                defaults: new { controller = "News", action = "Index", page = UrlParameter.Optional },
                namespaces: new string[] { "Web.Controllers" }
            );

            routes.MapRoute(
                name: "NewsDetail",
                url: "haber-detayi/{slug}/{id}",
                defaults: new { controller = "News", action = "Detail", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                namespaces: new string[] { "Web.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Web.Controllers" }
            );
        }
    }
}
