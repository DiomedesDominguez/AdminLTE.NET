// ***********************************************************************
// Assembly         : DNMOFT.Web
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="Global.asax.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace DNMOFT.Web
{
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