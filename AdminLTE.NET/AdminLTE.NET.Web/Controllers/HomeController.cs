// ***********************************************************************
// Assembly         : AdminLTE.NET.Web
// Author           : Diomedes Domínguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Domínguez
// Last Modified On : 2019-09-16
// ***********************************************************************
// <copyright file="HomeController.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.Web.Controllers
{
    using AdminLTE.NET.Web.Helper;
    using MvcThrottle;
    using System.Web.Mvc;

    /// <summary>
    /// Class HomeController.
    /// Implements the <see cref="System.Web.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    [CompressFilter, EnableThrottling]
    public class HomeController : Controller
    {
        #region Methods

        /// <summary>
        /// Abouts this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Contacts this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            return View();
        }

        #endregion Methods
    }
}