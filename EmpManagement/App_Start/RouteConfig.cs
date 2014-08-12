using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EmpManagement
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Employee",
               url: "{controller}/{action}/{id}"
               
           );

            routes.MapRoute(
              name: "Department",
              url: "{controller}/{action}/{id}"
            
          );
        }
    }
}
