﻿using System.Web.Mvc;
using System.Web.Routing;
using UCosmic.Www.Mvc.Mappers;

namespace UCosmic.Www.Mvc.Areas.My.Routes
{
    public static class EmailAddressesRoutes
    {
        private static readonly string Area = MVC.My.Name;
        private static readonly string Controller = MVC.My.EmailAddresses.Name;

        public static void RegisterRoutes(AreaRegistrationContext context)
        {
            DefaultRouteMapper.RegisterRoutes(typeof(EmailAddressesRoutes), context, Area, Controller);
        }

        // ReSharper disable UnusedMember.Global

        public static class ChangeSpelling
        {
            public const string Route = "my/emails/{number}/change-spelling";
            private static readonly string Action = MVC.My.EmailAddresses.ActionNames.ChangeSpelling;
            public static void MapRoutes(AreaRegistrationContext context, string area, string controller)
            {
                var defaults = new { area, controller, action = Action, };
                var constraints = new
                {
                    httpMethod = new HttpMethodConstraint("GET", "POST", "PUT")
                };
                context.MapRoute(null, Route, defaults, constraints);
            }
        }

        public static class ValidateChangeSpelling
        {
            public const string Route = "my/emails/{number}/change-spelling/validate";
            private static readonly string Action = MVC.My.EmailAddresses.ActionNames.ValidateChangeSpelling;
            public static void MapRoutes(AreaRegistrationContext context, string area, string controller)
            {
                var defaults = new { area, controller, action = Action, };
                var constraints = new { httpMethod = new HttpMethodConstraint("POST") };
                context.MapRoute(null, Route, defaults, constraints);
            }
        }

        // ReSharper restore UnusedMember.Global
    }
}