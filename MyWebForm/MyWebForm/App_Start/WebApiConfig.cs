using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Http.WebHost;
using System.Web.SessionState;

namespace MyWebForm.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            RouteTable.Routes.MapHttpRoute(
                name: "QueryApi",
                routeTemplate: "api/{controller}/{action}/{captcha}",
                defaults: new { action = RouteParameter.Optional, captcha = RouteParameter.Optional }
            ).RouteHandler = new SessionControllerRouteHandler();
            /*config.Routes.MapHttpRoute(
                name: "LoginApi",
                routeTemplate: "api/{controller}/{action}/{user}/{pwd}",
                defaults: new { action = RouteParameter.Optional, user = RouteParameter.Optional, pwd = RouteParameter.Optional }
            );
            RouteTable.Routes.MapHttpRoute(
                name: "LoginApi",
                 routeTemplate: "api/{controller}/{action}/{user}/{pwd}",
                defaults: new { action = RouteParameter.Optional, user = RouteParameter.Optional, pwd = RouteParameter.Optional }
            ).RouteHandler = new SessionControllerRouteHandler();*/

            //var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/json");
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/*");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

        }
        public class SessionRouteHandler : HttpControllerHandler, IRequiresSessionState
        {
            public SessionRouteHandler(RouteData routeData)
                : base(routeData)
            { }
        }
        public class SessionControllerRouteHandler : HttpControllerRouteHandler
        {
            protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
            {
                return new SessionRouteHandler(requestContext.RouteData);
            }
        }
    }
}