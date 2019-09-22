// ***********************************************************************
// Assembly         : AdminLTE.NET.Web
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="WebApiConfig.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.Web
{
    using System.Web.Http;

    using WebApiThrottle;

    /// <summary>
    /// Class WebApiConfig.
    /// </summary>
    public static class WebApiConfig
    {
        #region Methods

        /// <summary>
        /// Registers the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MessageHandlers.Add(new ThrottlingHandler()
            {
                //TODO: This policy must be changed according to you.
                Policy = new ThrottlePolicy(perSecond: 1, perMinute: 20, perHour: 200, perDay: 1500, perWeek: 3000)
                {
                    IpThrottling = true,
                    EndpointThrottling = true,
                    StackBlockedRequests = true
                },
                Repository = new CacheRepository()
            });
        }

        #endregion Methods
    }
}