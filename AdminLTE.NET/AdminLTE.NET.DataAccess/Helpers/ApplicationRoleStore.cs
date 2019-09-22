// ***********************************************************************
// Assembly         : AdminLTE.NET.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="ApplicationRoleStore.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.DataAccess.Helpers
{
    using System.Data.Entity;

    using AdminLTE.NET.DataAccess.Contexts;
    using AdminLTE.NET.DataAccess.Entities.Identity;

    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    /// Class ApplicationRoleStore.
    /// Implements the <see cref="Microsoft.AspNet.Identity.EntityFramework.RoleStore{AdminLTE.NET.DataAccess.Entities.Identity.mRole, System.Int64, AdminLTE.NET.DataAccess.Entities.Identity.mUserRole}" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.RoleStore{AdminLTE.NET.DataAccess.Entities.Identity.mRole, System.Int64, AdminLTE.NET.DataAccess.Entities.Identity.mUserRole}" />
    public class ApplicationRoleStore : RoleStore<mRole, long, mUserRole>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRoleStore" /> class.
        /// </summary>
        public ApplicationRoleStore()
            : base(new ApplicationContext())
        {
            DisposeContext = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRoleStore" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ApplicationRoleStore(DbContext context)
            : base(context)
        {
        }

        #endregion Constructors
    }
}