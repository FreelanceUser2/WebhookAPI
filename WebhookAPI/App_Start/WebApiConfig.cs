using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebhookAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.InitializeReceiveGitHubWebHooks();
            // Add a route for the webhook endpoint
            config.Routes.MapHttpRoute(
                name: "Values",
                routeTemplate: "api/Values",
                defaults: new { controller = "Values" }
            );
        }
    }
}
