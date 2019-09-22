// ***********************************************************************
// Assembly         : AdminLTE.NET.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="EmailService.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.DataAccess.Helpers
{
    using Microsoft.AspNet.Identity;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    /// <summary>
    /// Class EmailService.
    /// Implements the <see cref="Microsoft.AspNet.Identity.IIdentityMessageService" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.IIdentityMessageService" />
    public class EmailService : IIdentityMessageService
    {
        #region Methods

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Send(IdentityMessage message)
        {
            var client = new SmtpClient { EnableSsl = true };
            var mail = new MailMessage(((NetworkCredential)client.Credentials).UserName, message.Destination)
            {
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = true
            };

            client.Send(mail);
        }

        /// <summary>
        /// Sends the asynchronous.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>Task.</returns>
        public Task SendAsync(IdentityMessage message)
        {
            var client = new SmtpClient { EnableSsl = true };
            var mail = new MailMessage(((NetworkCredential)client.Credentials).UserName, message.Destination)
            {
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = true
            };

            return client.SendMailAsync(mail);
        }

        #endregion Methods
    }
}