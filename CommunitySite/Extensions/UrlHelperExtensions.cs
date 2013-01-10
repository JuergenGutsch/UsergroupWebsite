using System;
using System.Web.Mvc;

namespace CommunitySite.Extensions
{
    public static  class UrlHelperExtensions
    {
            public static bool IsCurrent(this UrlHelper urlHelper, String areaName,
                String controllerName, params String[] actionNames)
            {
                return urlHelper.RequestContext.IsCurrentRoute(areaName, controllerName, actionNames);
            }

            public static string Selected(this UrlHelper urlHelper, String areaName,
                String controllerName, params String[] actionNames)
            {
                return urlHelper.IsCurrent(areaName, controllerName, actionNames)
                    ? "selected" : String.Empty;
            }

    }
}