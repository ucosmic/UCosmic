﻿using System.Web.Mvc;
using UCosmic.Www.Mvc.Areas.Common.Mappers;

namespace UCosmic.Www.Mvc.Areas.Common
{
    public class CommonAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "common"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            FeaturesRouteMapper.RegisterRoutes(context);
            ErrorsRouteMapper.RegisterRoutes(context);
            HealthRouteMapper.RegisterRoutes(context);
            NavigationRouteMapper.RegisterRoutes(context);
            SkinsRouteMapper.RegisterRoutes(context);
            QaRouteMapper.RegisterRoutes(context);

            //context.MapRoute(
            //    "Common_default",
            //    "Common/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
