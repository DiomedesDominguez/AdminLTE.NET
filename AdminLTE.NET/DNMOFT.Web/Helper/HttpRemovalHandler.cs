// ***********************************************************************
// Assembly         : DNMOFT.Web
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="HttpRemovalHandler.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace DNMOFT.Web.Helper
{
    using System;
    using System.Web;

    /// <summary>
    /// Class HttpRemovalHandler.
    /// Implements the <see cref="System.Web.IHttpModule" />
    /// </summary>
    /// <seealso cref="System.Web.IHttpModule" />
    public class HttpRemovalHandler : IHttpModule
    {
        #region Methods

        /// <summary>
        /// Disposes of the resources (other than memory) used by the module that implements <see cref="T:System.Web.IHttpModule" />.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// Initializes a module and prepares it to handle requests.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpApplication" /> that provides access to the methods, properties, and events common to all application objects within an ASP.NET application</param>
        public void Init(HttpApplication context)
        {
            context.EndRequest += Context_EndRequest;
        }

        /// <summary>
        /// Handles the EndRequest event of the Context control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Context_EndRequest(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;
            response.Headers.Remove("X-AspNet-Version");
            response.Headers.Remove("Server");
            response.Headers.Remove("ETag");
            response.Headers.Remove("X-Powered-By");
        }

        #endregion Methods
    }
}