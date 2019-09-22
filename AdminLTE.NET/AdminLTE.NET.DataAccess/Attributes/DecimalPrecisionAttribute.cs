// ***********************************************************************
// Assembly         : AdminLTE.NET.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="DecimalPrecisionAttribute.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.DataAccess.Attributes
{
    using System;

    /// <summary>
    /// Class DecimalPrecisionAttribute.
    /// Implements the <see cref="System.Attribute" />
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property)]
    public class DecimalPrecisionAttribute : Attribute
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DecimalPrecisionAttribute" /> class.
        /// </summary>
        /// <param name="precision">The precision.</param>
        /// <param name="scale">The scale.</param>
        public DecimalPrecisionAttribute(byte precision = 18, byte scale = 2)
        {
            Precision = precision;
            Scale = scale;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the precision.
        /// </summary>
        /// <value>The precision.</value>
        public byte Precision { get; set; }

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        /// <value>The scale.</value>
        public byte Scale { get; set; }

        #endregion Properties
    }
}