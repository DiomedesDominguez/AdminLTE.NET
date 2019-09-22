// ***********************************************************************
// Assembly         : AdminLTE.NET.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="ApplicationRoleManager.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.DataAccess.Helpers
{
    using AdminLTE.NET.DataAccess.Contexts;
    using AdminLTE.NET.DataAccess.Entities.Identity;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;

    /// <summary>
    /// Class ApplicationRoleManager.
    /// Implements the <see cref="Microsoft.AspNet.Identity.RoleManager{AdminLTE.NET.DataAccess.Entities.Identity.mRole, System.Int64}" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.RoleManager{AdminLTE.NET.DataAccess.Entities.Identity.mRole, System.Int64}" />
    public class ApplicationRoleManager : RoleManager<mRole, long>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRoleManager" /> class.
        /// </summary>
        /// <param name="roleStore">The role store.</param>
        public ApplicationRoleManager(IRoleStore<mRole, long> roleStore)
            : base(roleStore)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Creates the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="context">The context.</param>
        /// <returns>ApplicationRoleManager.</returns>
        public static ApplicationRoleManager Create(
            IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(
                new ApplicationRoleStore(context.Get<ApplicationContext>()));
        }

        #endregion Methods
    }
}