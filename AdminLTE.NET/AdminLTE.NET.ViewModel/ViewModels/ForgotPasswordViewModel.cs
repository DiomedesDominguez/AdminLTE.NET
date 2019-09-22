// ***********************************************************************
// Assembly         : AdminLTE.NET.ViewModel
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="ForgotPasswordViewModel.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations;

namespace AdminLTE.NET.ViewModel
{
    /// <summary>
    /// Class ForgotPasswordViewModel.
    /// </summary>
    public class ForgotPasswordViewModel
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
