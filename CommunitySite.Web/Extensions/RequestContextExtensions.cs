using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;

namespace CommunitySite.Web.Extensions
{
    public static class RequestContextExtensions
    {
        public static bool IsCurrentRoute(this RequestContext context, String areaName, String controllerName, params String[] actionNames)
        {
            var routeData = context.RouteData;
            var routeArea = routeData.DataTokens["area"] as String;

            return IsRouteAreaValid(areaName, routeArea) &&
                   IsControllerValid(controllerName, routeData) &&
                   IsActionValid(actionNames, routeData);
        }

        private static bool IsActionValid(IEnumerable<string> actionNames, RouteData routeData)
        {
            return ((actionNames == null) || actionNames.Contains(routeData.GetRequiredString("action")));
        }

        private static bool IsControllerValid(string controllerName, RouteData routeData)
        {
            return ((String.IsNullOrEmpty(controllerName)) || (routeData.GetRequiredString("controller") == controllerName));
        }

        private static bool IsRouteAreaValid(string areaName, string routeArea)
        {
            return ((String.IsNullOrEmpty(routeArea) && String.IsNullOrEmpty(areaName)) || (routeArea == areaName));
        }
    }
}