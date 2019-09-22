// ***********************************************************************
// Assembly         : AdminLTE.NET.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="IBaseEntity.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.DataAccess.Interfaces
{
    using System;

    using AdminLTE.NET.DataAccess.Enums;

    /// <summary>
    /// Interface IBaseEntity
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IBaseEntity : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets or sets the client ip.
        /// </summary>
        /// <value>The client ip.</value>
        string ClientIp { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        long CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        long Id { get; set; }

        /// <summary>
        /// Gets or sets the last modified at.
        /// </summary>
        /// <value>The last modified at.</value>
        DateTime LastModifiedAt { get; set; }

        /// <summary>
        /// Gets or sets the last modified by.
        /// </summary>
        /// <value>The last modified by.</value>
        long LastModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the state of the record.
        /// </summary>
        /// <value>The state of the record.</value>
        RecordState RecordState { get; set; }

        #endregion Properties
    }
}