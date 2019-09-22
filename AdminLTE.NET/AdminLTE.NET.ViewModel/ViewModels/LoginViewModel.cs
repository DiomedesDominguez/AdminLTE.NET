// ***********************************************************************
// Assembly         : AdminLTE.NET.ViewModel
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="LoginViewModel.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.ViewModel
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Class LoginViewModel.
    /// </summary>
    public class LoginViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [remember me].
        /// </summary>
        /// <value><c>true</c> if [remember me]; otherwise, <c>false</c>.</value>
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        #endregion Properties
    }
}