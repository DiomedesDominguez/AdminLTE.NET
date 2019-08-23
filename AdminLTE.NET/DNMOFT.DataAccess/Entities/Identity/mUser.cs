// ***********************************************************************
// Assembly         : DNMOFT.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="mUser.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace DNMOFT.DataAccess.Entities.Identity
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using DNMOFT.DataAccess.Enums;
    using DNMOFT.DataAccess.Helpers;
    using DNMOFT.DataAccess.Interfaces;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    /// Class mUser.
    /// Implements the <see cref="Microsoft.AspNet.Identity.EntityFramework.IdentityUser{System.Int64, DNMOFT.DataAccess.Entities.Identity.mUserLogin, DNMOFT.DataAccess.Entities.Identity.mUserRole, DNMOFT.DataAccess.Entities.Identity.mUserClaim}" />
    /// Implements the <see cref="DNMOFT.DataAccess.Interfaces.IBaseEntity" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.IdentityUser{System.Int64, DNMOFT.DataAccess.Entities.Identity.mUserLogin, DNMOFT.DataAccess.Entities.Identity.mUserRole, DNMOFT.DataAccess.Entities.Identity.mUserClaim}" />
    /// <seealso cref="DNMOFT.DataAccess.Interfaces.IBaseEntity" />
    [Table("mUsers"),
    TrackChanges]
    public class mUser : IdentityUser<long, mUserLogin, mUserRole, mUserClaim>, IBaseEntity
    {
        #region Fields

        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed = false;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="mUser"/> class.
        /// </summary>
        public mUser()
        {
            ClientIp = "127.0.0.1";
            RecordState = RecordState.Active;
        }

        // the finalizer
        /// <summary>
        /// Finalizes an instance of the <see cref="mUser"/> class.
        /// </summary>
        ~mUser()
        {
            Dispose(false);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the client ip.
        /// </summary>
        /// <value>The client ip.</value>
        [Required]
        [MaxLength(15)]
        [DefaultValue("'127.0.0.1'")]
        public string ClientIp { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("SYSDATETIME()")]
        [Column(TypeName = "DateTime2")]
        [Required,
        SkipTracking]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        [Required]
        [DefaultValue("1"),
        SkipTracking]
        public long CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [MaxLength(30)]
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>The full name.</value>
        [NotMapped]
        public string FullName => string.Concat(FirstName, " ", LastName);

        /// <summary>
        /// Gets or sets the last modified at.
        /// </summary>
        /// <value>The last modified at.</value>
        [Required]
        [DefaultValue("SYSDATETIME()")]
        [Column(TypeName = "DateTime2")]
        public DateTime LastModifiedAt { get; set; }

        /// <summary>
        /// Gets or sets the last modified by.
        /// </summary>
        /// <value>The last modified by.</value>
        [Required]
        [DefaultValue("1")]
        public long LastModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [MaxLength(30)]
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the state of the record.
        /// </summary>
        /// <value>The state of the record.</value>
        [Required]
        [DefaultValue(1)]
        public RecordState RecordState { get; set; }

        #endregion Properties

        #region Methods

        // Implement IDisposable
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// generate user identity as an asynchronous operation.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <param name="authenticationType">Type of the authentication.</param>
        /// <returns>Task&lt;ClaimsIdentity&gt;.</returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager, string authenticationType = DefaultAuthenticationTypes.ApplicationCookie)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            userIdentity.AddClaim(new Claim("FullName", FullName));

            userIdentity.AddClaim(new Claim("FirstName", FirstName));
            userIdentity.AddClaim(new Claim("LastName", LastName));

            return userIdentity;
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // called via myClass.Dispose().
                    // OK to use any private object references
                }
                // Release unmanaged resources.
                // Set large fields to null.
                disposed = true;
            }
        }

        #endregion Methods
    }
}