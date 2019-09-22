// ***********************************************************************
// Assembly         : AdminLTE.NET.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="CustomEntityConfigurations.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.DataAccess.Helpers
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using AdminLTE.NET.DataAccess.Entities.Identity;

    /// <summary>
    /// Class CustomEntityConfigurations.
    /// </summary>
    public static class CustomEntityConfigurations
    {
        #region Methods

        /// <summary>
        /// Registers the identity tables.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public static void RegisterIdentityTables(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<mUser>().ToTable("mUsers").Property(x => x.Id).HasColumnOrder(1);
            modelBuilder.Entity<mUser>().Property(x => x.UserName).HasColumnOrder(2);
            modelBuilder.Entity<mUser>().Property(x => x.PasswordHash).HasColumnOrder(3);
            modelBuilder.Entity<mUser>().Property(x => x.Email).HasColumnOrder(4);
            modelBuilder.Entity<mUser>().Property(x => x.FirstName).HasColumnOrder(5);
            modelBuilder.Entity<mUser>().Property(x => x.LastName).HasColumnOrder(6);
            modelBuilder.Entity<mUser>().Property(x => x.CreatedAt).HasColumnType("datetime2");
            modelBuilder.Entity<mUser>().Property(x => x.LastModifiedAt).HasColumnType("datetime2");

            modelBuilder.Entity<mUserRole>().ToTable("mUsersRoles").Property(x => x.Id).HasColumnOrder(1);
            modelBuilder.Entity<mUserRole>().Property(x => x.CreatedAt).HasColumnType("datetime2");
            modelBuilder.Entity<mUserRole>().Property(x => x.LastModifiedAt).HasColumnType("datetime2");

            modelBuilder.Entity<mUserLogin>().ToTable("mUsersLogins").Property(x => x.Id).HasColumnOrder(1);
            modelBuilder.Entity<mUserLogin>().Property(x => x.CreatedAt).HasColumnType("datetime2");
            modelBuilder.Entity<mUserLogin>().Property(x => x.LastModifiedAt).HasColumnType("datetime2");

            modelBuilder.Entity<mUserClaim>().ToTable("mUsersClaims").Property(x => x.Id).HasColumnOrder(1);
            modelBuilder.Entity<mUserClaim>().Property(x => x.CreatedAt).HasColumnType("datetime2");
            modelBuilder.Entity<mUserClaim>().Property(x => x.LastModifiedAt).HasColumnType("datetime2");

            modelBuilder.Entity<mRole>().ToTable("mRoles").Property(x => x.Id).HasColumnOrder(1);
            modelBuilder.Entity<mRole>().Property(x => x.Name).HasColumnOrder(2);
            modelBuilder.Entity<mRole>().Property(x => x.Description).HasColumnOrder(3);
            modelBuilder.Entity<mRole>().Property(x => x.CreatedAt).HasColumnType("datetime2");
            modelBuilder.Entity<mRole>().Property(x => x.LastModifiedAt).HasColumnType("datetime2");
        }

        #endregion Methods
    }
}