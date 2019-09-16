// ***********************************************************************
// Assembly         : DNMOFT.Web
// Author           : Diomedes Domínguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Domínguez
// Last Modified On : 2019-09-16
// ***********************************************************************
// <copyright file="ManageViewModels.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace DNMOFT.ViewModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;

    /// <summary>
    /// Class AddPhoneNumberViewModel.
    /// </summary>
    public class AddPhoneNumberViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Class ChangePasswordViewModel.
    /// </summary>
    public class ChangePasswordViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        /// <value>The confirm password.</value>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Creates new password.
        /// </summary>
        /// <value>The new password.</value>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        /// <summary>
        /// Gets or sets the old password.
        /// </summary>
        /// <value>The old password.</value>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Class ConfigureTwoFactorViewModel.
    /// </summary>
    public class ConfigureTwoFactorViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the providers.
        /// </summary>
        /// <value>The providers.</value>
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }

        /// <summary>
        /// Gets or sets the selected provider.
        /// </summary>
        /// <value>The selected provider.</value>
        public string SelectedProvider { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Class FactorViewModel.
    /// </summary>
    public class FactorViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the purpose.
        /// </summary>
        /// <value>The purpose.</value>
        public string Purpose { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Class IndexViewModel.
    /// </summary>
    public class IndexViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether [browser remembered].
        /// </summary>
        /// <value><c>true</c> if [browser remembered]; otherwise, <c>false</c>.</value>
        public bool BrowserRemembered { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has password.
        /// </summary>
        /// <value><c>true</c> if this instance has password; otherwise, <c>false</c>.</value>
        public bool HasPassword { get; set; }

        /// <summary>
        /// Gets or sets the logins.
        /// </summary>
        /// <value>The logins.</value>
        public IList<UserLoginInfo> Logins { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>The phone number.</value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [two factor].
        /// </summary>
        /// <value><c>true</c> if [two factor]; otherwise, <c>false</c>.</value>
        public bool TwoFactor { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Class ManageLoginsViewModel.
    /// </summary>
    public class ManageLoginsViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the current logins.
        /// </summary>
        /// <value>The current logins.</value>
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        /// <summary>
        /// Gets or sets the other logins.
        /// </summary>
        /// <value>The other logins.</value>
        public IList<AuthenticationDescription> OtherLogins { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Class SetPasswordViewModel.
    /// </summary>
    public class SetPasswordViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        /// <value>The confirm password.</value>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Creates new password.
        /// </summary>
        /// <value>The new password.</value>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Class VerifyPhoneNumberViewModel.
    /// </summary>
    public class VerifyPhoneNumberViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>The phone number.</value>
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        #endregion Properties
    }
}