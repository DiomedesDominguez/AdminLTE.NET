// ***********************************************************************
// Assembly         : AdminLTE.NET.Web
// Author           : Diomedes Domínguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Domínguez
// Last Modified On : 2019-09-16
// ***********************************************************************
// <copyright file="BundleConfig.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.Web
{
    using System.Web.Optimization;

    /// <summary>
    /// Class BundleConfig.
    /// </summary>
    public class BundleConfig
    {
        #region Methods

        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        /// <summary>
        /// Registers the bundles.
        /// </summary>
        /// <param name="bundles">The bundles.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                      "~/Scripts/jquery.validate.js",
                      "~/Scripts/jquery.validate.unobtrusive.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/jquery-{version}.js",
                      "~/Scripts/bootstrap.bundle.js",
                      "~/Scripts/AdminLTE/adminlte.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/fontawesome.css",
                      "~/Content/css/adminlte.css",
                      "~/Content/site.css"));
        }

        #endregion Methods
    }
}