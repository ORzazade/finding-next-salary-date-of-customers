using System.Net.Http.Formatting;
using System.Web.Http;

namespace FNSD.Service
{
  /// <summary>
  /// Config for api
  /// </summary>
  public static class WebApiConfig
  {
    /// <summary>
    /// Config api 
    /// </summary>
    /// <param name="config"></param>
    public static void Register(HttpConfiguration config)
    {
      // Web API configuration and services

      // Web API routes
      config.MapHttpAttributeRoutes();

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );
      GlobalConfiguration.Configuration.Formatters.Clear();
      GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());

    }
  }
}

