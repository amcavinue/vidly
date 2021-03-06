﻿using System;
using System.Web;
using System.Web.Optimization;

namespace Vidly
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/datatables/jquery.datatables.js",
                        "~/Scripts/datatables/datatables.bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-lumen.css",
                      "~/Content/datatables/css/datatables.bootstrap.css",
                      "~/Content/angular-material/angular-material.min.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include(
                    "~/Scripts/readmore.min.js",
                    "~/Scripts/angular.min.js",
                    "~/Scripts/angular-route.min.js",
                    "~/Scripts/AngularUI/ui-router.min.js",
                    "~/Scripts/angular-material.min.js",
                    "~/Scripts/angular-aria.min.js",
                    "~/Scripts/angular-animate.min.js")
                .IncludeDirectory("~/Scripts/Controllers", "*.js")
                .IncludeDirectory("~/Scripts/Factories", "*.js")
                .IncludeDirectory("~/Scripts/Directives", "*.js")
                .Include("~/Scripts/VidlyAngular.js"));
        }
    }
}
