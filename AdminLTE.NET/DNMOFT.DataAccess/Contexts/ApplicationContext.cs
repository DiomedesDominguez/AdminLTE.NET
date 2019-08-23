// ***********************************************************************
// Assembly         : DNMOFT.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="ApplicationContext.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace DNMOFT.DataAccess.Contexts
{
    using System;
    using System.ComponentModel;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Configuration;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using DNMOFT.DataAccess.Attributes;
    using DNMOFT.DataAccess.Entities;
    using DNMOFT.DataAccess.Entities.Identity;
    using DNMOFT.DataAccess.Helpers;

    using TrackerEnabledDbContext.Identity;

    /// <summary>
    /// Class ApplicationContext.
    /// Implements the <see cref="TrackerEnabledDbContext.Identity.TrackerIdentityContext{DNMOFT.DataAccess.Entities.Identity.mUser, DNMOFT.DataAccess.Entities.Identity.mRole, System.Int64, DNMOFT.DataAccess.Entities.Identity.mUserLogin, DNMOFT.DataAccess.Entities.Identity.mUserRole, DNMOFT.DataAccess.Entities.Identity.mUserClaim}" />
    /// </summary>
    /// <seealso cref="TrackerEnabledDbContext.Identity.TrackerIdentityContext{DNMOFT.DataAccess.Entities.Identity.mUser, DNMOFT.DataAccess.Entities.Identity.mRole, System.Int64, DNMOFT.DataAccess.Entities.Identity.mUserLogin, DNMOFT.DataAccess.Entities.Identity.mUserRole, DNMOFT.DataAccess.Entities.Identity.mUserClaim}" />
    public class ApplicationContext : TrackerIdentityContext<mUser, mRole, long, mUserLogin, mUserRole, mUserClaim>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext" /> class.
        /// </summary>
        public ApplicationContext()
            : base("cnnApp")
        {
            Database.SetInitializer(new ApplicationContextInitializer());
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the client ip.
        /// </summary>
        /// <value>The client ip.</value>
        public string ClientIp { get; set; }

        /// <summary>
        /// Gets or sets the elmah.
        /// </summary>
        /// <value>The elmah.</value>
        public DbSet<ELMAH_Error> Elmah { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public long UserId { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ApplicationContext.</returns>
        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public override int SaveChanges()
        {
            if (UserId == 0)
            {
                ConfigureUsername("System");
            }
            else
            {
                ConfigureUsername(Users.FirstOrDefault(x => x.Id == UserId).UserName);
            }
            return base.SaveChanges();
        }

        /// <summary>
        /// Maps table names, and sets up relationships between the various user entities
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.RegisterIdentityTables();

            var convention = new AttributeToColumnAnnotationConvention<DefaultValueAttribute, string>(
                "SqlDefaultValue", (p, attributes) => attributes.FirstOrDefault()?.Value.ToString());

            modelBuilder.Conventions.Add(convention);
            foreach (var classType in from t in Assembly.GetAssembly(typeof(DecimalPrecisionAttribute)).GetTypes()
                                      where t.IsClass && t.Namespace != null && t.Namespace.Contains("DataAccess.Entities")
                                      select t)
            {
                foreach (
                    var propAttr in
                    classType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .Where(p => p.GetCustomAttribute<DecimalPrecisionAttribute>() != null)
                        .Select(
                            p => new { prop = p, attr = p.GetCustomAttribute<DecimalPrecisionAttribute>(true) }))
                {
                    var entityConfig =
                        modelBuilder.GetType()
                            .GetMethod("Entity")
                            .MakeGenericMethod(classType)
                            .Invoke(modelBuilder, null);
                    var param = Expression.Parameter(classType, "c");
                    var property = Expression.Property(param, propAttr.prop.Name);
                    var lambdaExpression = Expression.Lambda(property, true, param);
                    var index = 6;
                    if (propAttr.prop.PropertyType.IsGenericType &&
                        propAttr.prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        index = 7;
                    }

                    var methodInfo =
                        entityConfig.GetType().GetMethods().Where(p => p.Name == "Property").ToList()[index];
                    var decimalConfig = methodInfo.Invoke(entityConfig, new object[] { lambdaExpression }) as
                        DecimalPropertyConfiguration;

                    decimalConfig?.HasPrecision(propAttr.attr.Precision, propAttr.attr.Scale);
                }
            }
        }

        #endregion Methods
    }
}