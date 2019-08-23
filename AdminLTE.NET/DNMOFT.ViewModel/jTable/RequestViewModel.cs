// ***********************************************************************
// Assembly         : DNMOFT.ViewModel
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="RequestViewModel.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace DNMOFT.ViewModel.jTable
{
    /// <summary>
    /// Class RequestViewModel.
    /// </summary>
    public class RequestViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the jt filter value.
        /// </summary>
        /// <value>The jt filter value.</value>
        public string jtFilterValue { get; set; }

        /// <summary>
        /// Gets or sets the jt identifier.
        /// </summary>
        /// <value>The jt identifier.</value>
        public long? jtId { get; set; }

        /// <summary>
        /// Gets or sets the size of the jt page.
        /// </summary>
        /// <value>The size of the jt page.</value>
        public int jtPageSize { get; set; }

        /// <summary>
        /// Gets or sets the jt sorting.
        /// </summary>
        /// <value>The jt sorting.</value>
        public string jtSorting { get; set; }

        /// <summary>
        /// Gets or sets the start index of the jt.
        /// </summary>
        /// <value>The start index of the jt.</value>
        public int jtStartIndex { get; set; }

        #endregion Properties
    }
}