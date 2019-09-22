// ***********************************************************************
// Assembly         : AdminLTE.NET.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="mUserRole.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.DataAccess.Entities.Identity
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AdminLTE.NET.DataAccess.Enums;
    using AdminLTE.NET.DataAccess.Interfaces;

    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    /// Class mUserRole.
    /// Implements the <see cref="Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole{System.Int64}" />
    /// Implements the <see cref="AdminLTE.NET.DataAccess.Interfaces.IBaseEntity" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole{System.Int64}" />
    /// <seealso cref="AdminLTE.NET.DataAccess.Interfaces.IBaseEntity" />
    [Table("mUsersRoles"),
    TrackChanges]
    public class mUserRole : IdentityUserRole<long>, IBaseEntity
    {
        #region Fields

        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed = false;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="mUserRole"/> class.
        /// </summary>
        public mUserRole()
        {
            ClientIp = "127.0.0.1";
            RecordState = RecordState.Active;
        }

        // the finalizer
        /// <summary>
        /// Finalizes an instance of the <see cref="mUserRole"/> class.
        /// </summary>
        ~mUserRole()
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
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public long Id { get; set; }

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