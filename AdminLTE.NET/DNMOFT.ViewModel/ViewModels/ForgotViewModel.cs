// ***********************************************************************
// Assembly         : DNMOFT.ViewModel
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="ForgotViewModel.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations;

namespace DNMOFT.ViewModel
{
    /// <summary>
    /// Class ForgotViewModel.
    /// </summary>
    public class ForgotViewModel
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
