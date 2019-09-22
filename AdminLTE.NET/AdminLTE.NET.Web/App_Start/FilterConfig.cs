// ***********************************************************************
// Assembly         : AdminLTE.NET.Web
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="FilterConfig.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.Web
{
    using System.Web.Mvc;

    using MvcThrottle;

    /// <summary>
    /// Class FilterConfig.
    /// </summary>
    public class FilterConfig
    {
        #region Methods

        /// <summary>
        /// Registers the global filters.
        /// </summary>
        /// <param name="filters">The filters.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            var throttleMVCFilter = new ThrottlingFilter
            {
                //TODO: This policy must be changed according to you.
                Policy = new ThrottlePolicy(perSecond: 1, perMinute: 10, perHour: 60 * 10, perDay: 600 * 10)
                {
                    IpThrottling = true,
                    EndpointThrottling = true,
                    EndpointType = EndpointThrottlingType.ControllerAndAction,
                    StackBlockedRequests = true
                },
                Repository = new CacheRepository()
            };

            filters.Add(throttleMVCFilter);
        }

        #endregion Methods
    }
}