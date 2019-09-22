// ***********************************************************************
// Assembly         : 
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="JsonNetResult.cs" company="DNMOFT">
//     Copyright (c) AdminLTE.NET. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.Web.Helper
{
    using System;
    using System.IO;
    using System.Web.Mvc;

    using Newtonsoft.Json;

    /// <summary>
    /// Class JsonNetResult.
    /// Implements the <see cref="System.Web.Mvc.JsonResult" />
    /// </summary>
    /// <seealso cref="System.Web.Mvc.JsonResult" />
    public class JsonNetResult : JsonResult
    {
        #region Methods

        /// <summary>
        /// Executes the result.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="System.ArgumentNullException">context</exception>
        /// <exception cref="System.InvalidOperationException">JSON GET is not allowed</exception>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("JSON GET is not allowed");
            }

            var response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(ContentType) ? "application/json" : ContentType;

            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            if (Data == null)
            {
                return;
            }

            var scriptSerializer = JsonSerializer.CreateDefault();

            using (var sw = new StringWriter())
            {
                scriptSerializer.Serialize(sw, Data);
                response.Write(sw.ToString());
            }
        }

        #endregion Methods
    }
}