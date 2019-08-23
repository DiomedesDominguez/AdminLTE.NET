// ***********************************************************************
// Assembly         : DNMOFT.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="ApplicationUserStore.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace DNMOFT.DataAccess.Helpers
{
    using System.Data.Entity;

    using DNMOFT.DataAccess.Entities.Identity;

    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    /// Class ApplicationUserStore.
    /// Implements the <see cref="Microsoft.AspNet.Identity.EntityFramework.UserStore{DNMOFT.DataAccess.Entities.Identity.mUser, DNMOFT.DataAccess.Entities.Identity.mRole, System.Int64, DNMOFT.DataAccess.Entities.Identity.mUserLogin, DNMOFT.DataAccess.Entities.Identity.mUserRole, DNMOFT.DataAccess.Entities.Identity.mUserClaim}" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.UserStore{DNMOFT.DataAccess.Entities.Identity.mUser, DNMOFT.DataAccess.Entities.Identity.mRole, System.Int64, DNMOFT.DataAccess.Entities.Identity.mUserLogin, DNMOFT.DataAccess.Entities.Identity.mUserRole, DNMOFT.DataAccess.Entities.Identity.mUserClaim}" />
    public class ApplicationUserStore : UserStore<mUser, mRole, long, mUserLogin, mUserRole, mUserClaim>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserStore" /> class.
        /// </summary>
        public ApplicationUserStore()
            : this(new IdentityDbContext())
        {
            DisposeContext = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserStore" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ApplicationUserStore(DbContext context)
            : base(context)
        {
        }

        #endregion Constructors
    }
}