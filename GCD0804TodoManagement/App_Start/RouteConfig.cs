using System.Web.Mvc;
using System.Web.Routing;

namespace GCD0804TodoManagement
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
          name: "Default",
          url: "{controller}/{action}/{id}",
          defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
      );

      routes.MapRoute(
        name: "RemoveUser",
        url: "{controller}/{action}/{id}/{userid}",
        new { controller = "Teams", action = "RemoveUser", id = "", userId = "" }
      );
    }
  }
}
