// ***********************************************************************
// Assembly         : DNMOFT.ViewModel
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="SendCodeViewModel.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace DNMOFT.ViewModel.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// Class SendCodeViewModel.
    /// </summary>
    public class SendCodeViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the providers.
        /// </summary>
        /// <value>The providers.</value>
        public ICollection<OptionsViewModel> Providers { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [remember me].
        /// </summary>
        /// <value><c>true</c> if [remember me]; otherwise, <c>false</c>.</value>
        public bool RememberMe { get; set; }

        /// <summary>
        /// Gets or sets the return URL.
        /// </summary>
        /// <value>The return URL.</value>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// Gets or sets the selected provider.
        /// </summary>
        /// <value>The selected provider.</value>
        public string SelectedProvider { get; set; }

        #endregion Properties
    }
}