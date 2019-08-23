// ***********************************************************************
// Assembly         : DNMOFT.DataAccess
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
namespace DNMOFT.DataAccess.Helpers
{
    using System.Data.Entity;

    using DNMOFT.DataAccess.Contexts;
    using DNMOFT.DataAccess.Entities.Identity;

    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    /// Class ApplicationRoleStore.
    /// Implements the <see cref="Microsoft.AspNet.Identity.EntityFramework.RoleStore{DNMOFT.DataAccess.Entities.Identity.mRole, System.Int64, DNMOFT.DataAccess.Entities.Identity.mUserRole}" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.RoleStore{DNMOFT.DataAccess.Entities.Identity.mRole, System.Int64, DNMOFT.DataAccess.Entities.Identity.mUserRole}" />
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