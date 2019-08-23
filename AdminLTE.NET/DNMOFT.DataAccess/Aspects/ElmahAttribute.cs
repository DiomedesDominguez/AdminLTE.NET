// ***********************************************************************
// Assembly         : DNMOFT.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="ElmahAttribute.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace DNMOFT.DataAccess.Aspects
{
    using Elmah;

    using PostSharp.Aspects;
    using PostSharp.Serialization;

    /// <summary>
    /// Class ElmahAttribute.
    /// Implements the <see cref="PostSharp.Aspects.OnExceptionAspect" />
    /// </summary>
    /// <seealso cref="PostSharp.Aspects.OnExceptionAspect" />
    [PSerializable]
    [LinesOfCodeAvoided(4)]
    public class ElmahAttribute : OnExceptionAspect
    {
        #region Methods

        /// <summary>
        /// Method executed <b>after</b> the body of methods to which this aspect is applied,
        /// in case that the method resulted with an exception (i.e., in a <c>catch</c> block).
        /// </summary>
        /// <param name="args">Advice arguments.</param>
        public override sealed void OnException(MethodExecutionArgs args)
        {
            ErrorSignal.FromCurrentContext().Raise(args.Exception);
            args.FlowBehavior = FlowBehavior.ThrowException;
            base.OnException(args);
        }

        #endregion Methods
    }
}