// ***********************************************************************
// Assembly         : AdminLTE.NET.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="ITwilioMessageSender.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.DataAccess.Interfaces
{
    using System.Threading.Tasks;

    /// <summary>
    /// Interface ITwilioMessageSender
    /// </summary>
    public interface ITwilioMessageSender
    {
        #region Methods

        /// <summary>
        /// Sends the message asynchronous.
        /// </summary>
        /// <param name="to">To.</param>
        /// <param name="from">From.</param>
        /// <param name="body">The body.</param>
        /// <returns>Task.</returns>
        Task SendMessageAsync(string to, string from, string body);

        #endregion Methods
    }
}