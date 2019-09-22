// ***********************************************************************
// Assembly         : AdminLTE.NET.Web
// Author           : Diomedes Domínguez
// Created          : 2019-09-16
//
// Last Modified By : Diomedes Domínguez
// Last Modified On : 2019-09-16
// ***********************************************************************
// <copyright file="ErrorController.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using AdminLTE.NET.Web.Helper;

    using MvcThrottle;

    /// <summary>
    /// Class ErrorController.
    /// Implements the <see cref="System.Web.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    [CompressFilter,
    EnableThrottling]
    public class ErrorController : Controller
    {
        #region Methods

        /// <summary>
        /// Ajaxes the error.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>JsonResult.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        [HttpPost]
        public JsonResult AjaxError(string id)
        {
            throw new Exception(id);
        }

        // GET: Error
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Index(string id)
        {
            return View("Error");
        }

        /// <summary>
        /// Oopses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Oops(string id)
        {
            return View("Error");
        }

        #endregion Methods
    }
}