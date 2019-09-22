// ***********************************************************************
// Assembly         : AdminLTE.NET.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="ApplicationContextInitializer.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.DataAccess.Helpers
{
    using System;
    using System.Data.Entity;

    using AdminLTE.NET.DataAccess.Contexts;
    using AdminLTE.NET.DataAccess.Entities.Identity;

    using Microsoft.AspNet.Identity;

    /// <summary>
    /// Class ApplicationContextInitializer.
    /// Implements the <see cref="System.Data.Entity.CreateDatabaseIfNotExists{AdminLTE.NET.DataAccess.Contexts.ApplicationContext}" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.CreateDatabaseIfNotExists{AdminLTE.NET.DataAccess.Contexts.ApplicationContext}" />
    public class ApplicationContextInitializer : CreateDatabaseIfNotExists<ApplicationContext>
    {
        #region Methods

        /// <summary>
        /// Seeds the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        protected override void Seed(ApplicationContext context)
        {
            try
            {
                //TODO: Change the user data
                var myUser = new mUser
                {
                    Email = "Gmail@kaizer.soze",
                    UserName = "KaizerSoze",
                    FirstName = "I AM",
                    LastName = "ADMIN"
                };

                var myRole = new mRole
                {
                    Name = "Super User",
                    Description = "God mode in the system"
                };

                var userManager = new ApplicationUserManager(new ApplicationUserStore(context));

                var roleManager = new ApplicationRoleManager(new ApplicationRoleStore(context));

                var role = roleManager.FindByName(myRole.Name);

                if (role == null)
                {
                    role = myRole;

                    roleManager.Create(role);
                }

                var user = userManager.FindByName(myUser.UserName);

                if (user == null)
                {
                    user = myUser;

                    //TODO: Change the default password
                    userManager.Create(user, "zlcrAnlGoS8It*8sTep");
                }

                var rolesForUser = userManager.GetRoles(user.Id);

                if (rolesForUser.Contains(role.Name))
                {
                    return;
                }

                userManager.AddToRole(user.Id, role.Name);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                base.Seed(context);
            }
        }

        #endregion Methods
    }
}