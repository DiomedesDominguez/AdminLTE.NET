// ***********************************************************************
// Assembly         : DNMOFT.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="AppConfig.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace DNMOFT.DataAccess.Migrations
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.SqlServer;
    using System.IO;
    using System.Reflection;
    using System.Text;

    using DNMOFT.DataAccess.Contexts;
    using DNMOFT.DataAccess.Helpers;

    /// <summary>
    /// Class AppConfig. This class cannot be inherited.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigrationsConfiguration{DNMOFT.DataAccess.Contexts.ApplicationContext}" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigrationsConfiguration{DNMOFT.DataAccess.Contexts.ApplicationContext}" />
    internal sealed class AppConfig : DbMigrationsConfiguration<ApplicationContext>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfig"/> class.
        /// </summary>
        public AppConfig()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;

            SqlProviderServices.SqlServerTypesAssemblyName =
                "Microsoft.SqlServer.Types, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91";
            SetSqlGenerator("System.Data.SqlClient", new DefaultValueSqlServerMigrationSqlGenerator());
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Runs after upgrading to the latest migration to allow seed data to be updated.
        /// </summary>
        /// <param name="context">Context to be used for updating seed data.</param>
        /// <remarks>Note that the database may already contain seed data when this method runs. This means that
        /// implementations of this method must check whether or not seed data is present and/or up-to-date
        /// and then only make changes if necessary and in a non-destructive way. The
        /// <see cref="M:System.Data.Entity.Migrations.DbSetMigrationsExtensions.AddOrUpdate``1(System.Data.Entity.IDbSet{``0},``0[])" />
        /// can be used to help with this, but for seeding large amounts of data it may be necessary to do less
        /// granular checks if performance is an issue.
        /// If the <see cref="T:System.Data.Entity.MigrateDatabaseToLatestVersion`2" /> database
        /// initializer is being used, then this method will be called each time that the initializer runs.
        /// If one of the <see cref="T:System.Data.Entity.DropCreateDatabaseAlways`1" />, <see cref="T:System.Data.Entity.DropCreateDatabaseIfModelChanges`1" />,
        /// or <see cref="T:System.Data.Entity.CreateDatabaseIfNotExists`1" /> initializers is being used, then this method will not be
        /// called and the Seed method defined in the initializer should be used instead.</remarks>
        protected override void Seed(ApplicationContext context)
        {
            SqlFromFile("DeleteAll.sql", context);
            SqlFromFile("Create_ELMAH_GetErrorXml.sql", context);
            SqlFromFile("Create_ELMAH_GetErrorsXml.sql", context);
            SqlFromFile("Create_ELMAH_LogError.sql", context);

            base.Seed(context);
        }

        /// <summary>
        /// Execute SQLs commands from file.
        /// </summary>
        /// <param name="sqlFileName">Name of the SQL file.</param>
        /// <param name="context">The context.</param>
        /// <exception cref="FileNotFoundException">Could not find the embedded resource: " + sqlFileName</exception>
        private void SqlFromFile(string sqlFileName, DbContext context)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(GetType(), sqlFileName);

            if (stream == null)
            {
                throw new FileNotFoundException("Could not find the embedded resource: " + sqlFileName);
            }

            var sqlToExecute = new StreamReader(stream, Encoding.Default, true, 8192).ReadToEnd();

            context.Database.ExecuteSqlCommand(sqlToExecute);
        }

        #endregion Methods
    }
}