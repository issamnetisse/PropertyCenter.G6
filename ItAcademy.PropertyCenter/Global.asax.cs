﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ItAcademy.PropertyCenter.App_Start;

namespace ItAcademy.PropertyCenter
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            LoggingConfig.Configure();
            DeviceConfig.ConfigureDisplayMode();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleMobileConfig.RegisterBundles(BundleTable.Bundles);

            //ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());
        }
    }
}
