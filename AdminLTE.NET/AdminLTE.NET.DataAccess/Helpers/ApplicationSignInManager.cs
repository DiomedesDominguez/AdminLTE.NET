// ***********************************************************************
// Assembly         : AdminLTE.NET.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="ApplicationSignInManager.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.DataAccess.Helpers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AdminLTE.NET.DataAccess.Entities.Identity;

    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;

    /// <summary>
    /// Class ApplicationSignInManager.
    /// Implements the <see cref="Microsoft.AspNet.Identity.Owin.SignInManager{AdminLTE.NET.DataAccess.Entities.Identity.mUser, System.Int64}" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.Owin.SignInManager{AdminLTE.NET.DataAccess.Entities.Identity.mUser, System.Int64}" />
    public class ApplicationSignInManager : SignInManager<mUser, long>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationSignInManager" /> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="authenticationManager">The authentication manager.</param>
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Creates the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="context">The context.</param>
        /// <returns>ApplicationSignInManager.</returns>
        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options,
            IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }

        /// <summary>
        /// Creates the user identity asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Task&lt;ClaimsIdentity&gt;.</returns>
        public override Task<ClaimsIdentity> CreateUserIdentityAsync(mUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        #endregion Methods
    }
}