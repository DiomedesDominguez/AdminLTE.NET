// ***********************************************************************
// Assembly         : DNMOFT.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="BaseEntity.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace DNMOFT.DataAccess.Entities.Bases
{
    using DNMOFT.DataAccess.Enums;
    using DNMOFT.DataAccess.Interfaces;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class BaseEntity.
    /// Implements the <see cref="DNMOFT.DataAccess.Interfaces.IBaseEntity" />
    /// </summary>
    /// <seealso cref="DNMOFT.DataAccess.Interfaces.IBaseEntity" />
    public class BaseEntity : IBaseEntity
    {
        #region Fields

        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed = false;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntity"/> class.
        /// </summary>
        public BaseEntity()
        {
            ClientIp = "127.0.0.1";
            LastModifiedAt = DateTime.Now;
            RecordState = RecordState.Active;
        }

        // the finalizer
        /// <summary>
        /// Finalizes an instance of the <see cref="BaseEntity"/> class.
        /// </summary>
        ~BaseEntity()
        {
            Dispose(false);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the client ip.
        /// </summary>
        /// <value>The client ip.</value>
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
        [SkipTracking]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
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
        [DefaultValue("SYSDATETIME()")]
        [Column(TypeName = "DateTime2")]
        public DateTime LastModifiedAt { get; set; }

        /// <summary>
        /// Gets or sets the last modified by.
        /// </summary>
        /// <value>The last modified by.</value>
        [DefaultValue("1")]
        public long LastModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the state of the record.
        /// </summary>
        /// <value>The state of the record.</value>
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