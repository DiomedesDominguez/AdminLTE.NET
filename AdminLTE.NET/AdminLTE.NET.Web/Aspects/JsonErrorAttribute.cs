// ***********************************************************************
// Assembly         : 
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="JsonErrorAttribute.cs" company="DNMOFT">
//     Copyright (c) AdminLTE.NET. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.Web.Aspects
{
    using System.Data.Entity.Validation;
    using System.Text;
    using System.Web.Mvc;

    using AdminLTE.NET.Web.Helper;

    using PostSharp.Aspects;
    using PostSharp.Serialization;

    /// <summary>
    /// Class JsonErrorAttribute.
    /// Implements the <see cref="PostSharp.Aspects.OnExceptionAspect" />
    /// </summary>
    /// <seealso cref="PostSharp.Aspects.OnExceptionAspect" />
    [PSerializable,
    LinesOfCodeAvoided(36)]
    public class JsonErrorAttribute : OnExceptionAspect
    {
        #region Methods

        /// <summary>
        /// Called when [exception].
        /// </summary>
        /// <param name="args">The arguments.</param>
        public override sealed void OnException(MethodExecutionArgs args)
        {
            var t = args.Exception;
            if (t.GetType() == typeof(DbEntityValidationException))
            {
                var msg = new StringBuilder();
                foreach (var eve in (t as DbEntityValidationException).EntityValidationErrors)
                {
                    msg.AppendLine($"Entity \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following errors:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        msg.AppendLine($"- Property: \"{ve.PropertyName}\", Value: \"{eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName)}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                args.ReturnValue = new JsonNetResult
                {
                    Data = new { Result = "ERROR", Message = msg.ToString() },
                    JsonRequestBehavior = JsonRequestBehavior.DenyGet,
                    ContentEncoding = null,
                    ContentType = null
                };
            }
            else
            {
                while (t.InnerException != null)
                {
                    t = t.InnerException;
                }
                args.ReturnValue = new JsonNetResult
                {
                    Data = new { Result = "ERROR", t.Message },
                    JsonRequestBehavior = JsonRequestBehavior.DenyGet,
                    ContentEncoding = null,
                    ContentType = null
                };
            }
            args.FlowBehavior = FlowBehavior.Return;
            base.OnException(args);
        }

        #endregion Methods
    }
}