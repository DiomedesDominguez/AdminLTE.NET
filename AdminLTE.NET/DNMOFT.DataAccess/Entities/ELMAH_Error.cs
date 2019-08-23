// ***********************************************************************
// Assembly         : DNMOFT.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="ELMAH_Error.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace DNMOFT.DataAccess.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class ELMAH_Error.
    /// </summary>
    [Table("ELMAH_Error")]
    public class ELMAH_Error
    {
        #region Properties

        /// <summary>
        /// Gets or sets all XML.
        /// </summary>
        /// <value>All XML.</value>
        [Column(TypeName = "ntext")]
        [Required]
        public string AllXml { get; set; }

        /// <summary>
        /// Gets or sets the application.
        /// </summary>
        /// <value>The application.</value>
        [Required]
        [StringLength(60)]
        public string Application { get; set; }

        /// <summary>
        /// Gets or sets the error identifier.
        /// </summary>
        /// <value>The error identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ErrorId { get; set; }

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>The host.</value>
        [Required]
        [StringLength(50)]
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        [Required]
        [StringLength(500)]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the sequence.
        /// </summary>
        /// <value>The sequence.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sequence { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        [Required]
        [StringLength(60)]
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>The status code.</value>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the time UTC.
        /// </summary>
        /// <value>The time UTC.</value>
        public DateTime TimeUtc { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [Required]
        [StringLength(100)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        [Required]
        [StringLength(50)]
        public string User { get; set; }

        #endregion Properties
    }
}