// ***********************************************************************
// Assembly         : DNMOFT.ViewModel
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="BaseJTableResult.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace DNMOFT.ViewModel.Base
{
    using DNMOFT.ViewModel.Interfaces;

    /// <summary>
    /// Class BaseJTableResult.
    /// Implements the <see cref="DNMOFT.ViewModel.Interfaces.IJTableResult" />
    /// </summary>
    /// <seealso cref="DNMOFT.ViewModel.Interfaces.IJTableResult" />
    public class BaseJTableResult : IJTableResult
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseJTableResult"/> class.
        /// </summary>
        public BaseJTableResult()
        {
            Result = "OK";
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        public string Result { get; set; }

        #endregion Properties
    }
}