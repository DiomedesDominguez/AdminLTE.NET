// ***********************************************************************
// Assembly         : DNMOFT.Web
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="ExtensionsMethods.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace DNMOFT.Web.Helper
{
    using System.Web.Mvc;

    /// <summary>
    /// Class ExtensionsMethods.
    /// </summary>
    public static class ExtensionsMethods
    {
        #region Methods

        /// <summary>
        /// Determines whether the enviroment running is debug.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <returns><c>true</c> if the specified helper is debug; otherwise, <c>false</c>.</returns>
        public static bool IsDebug(this HtmlHelper helper)
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }

        #endregion Methods
    }
}