// ***********************************************************************
// Assembly         : DNMOFT.ViewModel
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="BaseViewModel.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace DNMOFT.ViewModel.Base
{
    using System;

    using DNMOFT.ViewModel.Interfaces;

    /// <summary>
    /// Class BaseViewModel.
    /// Implements the <see cref="DNMOFT.ViewModel.Interfaces.IBaseViewModel" />
    /// </summary>
    /// <seealso cref="DNMOFT.ViewModel.Interfaces.IBaseViewModel" />
    public class BaseViewModel : IBaseViewModel
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        public BaseViewModel()
        {
            LastModifiedAt = DateTime.Now;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the last modified at.
        /// </summary>
        /// <value>The last modified at.</value>
        public DateTime LastModifiedAt { get; set; }

        /// <summary>
        /// Gets or sets the state of the record.
        /// </summary>
        /// <value>The state of the record.</value>
        public byte RecordState { get; set; }

        #endregion Properties
    }
}