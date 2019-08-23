// ***********************************************************************
// Assembly         : DNMOFT.ViewModel
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="ResultViewModel.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace DNMOFT.ViewModel.jTable
{
    using Base;

    using Interfaces;

    /// <summary>
    /// Class JTableResult.
    /// Implements the <see cref="DNMOFT.ViewModel.Base.BaseJTableResult" />
    /// </summary>
    /// <typeparam name="TE">The type of the te.</typeparam>
    /// <seealso cref="DNMOFT.ViewModel.Base.BaseJTableResult" />
    public class ResultViewModel<TE> : BaseJTableResult
        where TE : class, IBaseViewModel, new()
    {
        #region Properties

        /// <summary>
        /// Gets or sets the record.
        /// </summary>
        /// <value>The record.</value>
        public TE Record { get; set; }

        #endregion Properties
    }
}