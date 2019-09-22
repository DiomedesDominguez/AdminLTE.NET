// ***********************************************************************
// Assembly         : AdminLTE.NET.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="ApplicationUserManager.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.DataAccess.Helpers
{
    using System;

    using AdminLTE.NET.DataAccess.Contexts;
    using AdminLTE.NET.DataAccess.Entities.Identity;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;

    /// <summary>
    /// Class ApplicationUserManager.
    /// Implements the <see cref="Microsoft.AspNet.Identity.UserManager{AdminLTE.NET.DataAccess.Entities.Identity.mUser, System.Int64}" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.UserManager{AdminLTE.NET.DataAccess.Entities.Identity.mUser, System.Int64}" />
    public class ApplicationUserManager : UserManager<mUser, long>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserManager" /> class.
        /// </summary>
        /// <param name="store">The store.</param>
        public ApplicationUserManager(IUserStore<mUser, long> store)
            : base(store)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Creates the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="context">The context.</param>
        /// <returns>ApplicationUserManager.</returns>
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext context)
        {
            var manager = new ApplicationUserManager(new ApplicationUserStore(context.Get<ApplicationContext>()));

            manager.UserValidator = new UserValidator<mUser, long>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(15);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<mUser, long>
            {
                MessageFormat = "{0} is your secret code."
            });

            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<mUser, long>
            {
                Subject = "Secret Code",
                BodyFormat = "<strong>{0}</strong> is your secret code."
            });

            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<mUser, long>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        #endregion Methods
    }
}