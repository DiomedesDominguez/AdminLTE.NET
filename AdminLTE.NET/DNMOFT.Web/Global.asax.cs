// ***********************************************************************
// Assembly         : DNMOFT.Web
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-09-16
// ***********************************************************************
// <copyright file="Global.asax.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace DNMOFT.Web
{
    using System;
    using System.Data.Entity.SqlServer;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using SqlServerTypes;

    /// <summary>
    /// Class MvcApplication.
    /// Implements the <see cref="System.Web.HttpApplication" />
    /// </summary>
    /// <seealso cref="System.Web.HttpApplication" />
    public class MvcApplication : System.Web.HttpApplication
    {
        #region Methods

        /// <summary>
        /// Handles the BeginRequest event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string[] headers = { "Server", "X-AspNet-Version", "ETag", "X-Powered-By" };

            if (!Response.HeadersWritten)
            {
                Response.AddOnSendingHeaders((c) =>
                {
                    if (c != null && c.Response != null && c.Response.Headers != null)
                    {
                        foreach (string header in headers)
                        {
                            if (c.Response.Headers[header] != null)
                            {
                                c.Response.Headers.Remove(header);
                            }
                        }
                    }
                });
            }
        }

        /// <summary>
        /// Applications the start.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SqlProviderServices.SqlServerTypesAssemblyName =
                "Microsoft.SqlServer.Types, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91";

            #pragma warning disable CS0436 // Type conflicts with imported type
            Utilities.LoadNativeAssemblies(Server.MapPath("~/bin"));
            #pragma warning restore CS0436 // Type conflicts with imported type
            MvcHandler.DisableMvcResponseHeader = true;
        }

        #endregion Methods
    }
}