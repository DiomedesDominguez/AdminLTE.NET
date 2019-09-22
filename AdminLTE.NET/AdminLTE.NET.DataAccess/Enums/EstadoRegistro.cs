// ***********************************************************************
// Assembly         : AdminLTE.NET.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="EstadoRegistro.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.DataAccess.Enums
{
    using System.ComponentModel;

    #region Enumerations

    /// <summary>
    /// Enum RecordState
    /// </summary>
    public enum RecordState : byte
    {
        /// <summary>
        /// The active
        /// </summary>
        [Description("Active")]
        Active = 1,

        /// <summary>
        /// The inactive
        /// </summary>
        [Description("Inactive")]
        Inactive = 2,

        /// <summary>
        /// The deleted
        /// </summary>
        [Description("Deleted")]
        Deleted = 3
    }

    #endregion Enumerations
}