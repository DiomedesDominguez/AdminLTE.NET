// ***********************************************************************
// Assembly         : DNMOFT.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="SmsService.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace DNMOFT.DataAccess.Helpers
{
    using System.Configuration;
    using System.Threading.Tasks;

    using DNMOFT.DataAccess.Interfaces;

    using Microsoft.AspNet.Identity;

    /// <summary>
    /// Class SmsService.
    /// Implements the <see cref="Microsoft.AspNet.Identity.IIdentityMessageService" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.IIdentityMessageService" />
    public class SmsService : IIdentityMessageService
    {
        #region Fields

        /// <summary>
        /// The twilio number
        /// </summary>
        private readonly string TwilioNumber = ConfigurationManager.AppSettings["TwilioNumber"] ?? "+123456";
        /// <summary>
        /// The message sender
        /// </summary>
        private readonly ITwilioMessageSender _messageSender;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsService"/> class.
        /// </summary>
        public SmsService()
            : this(new TwilioMessageSender())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsService"/> class.
        /// </summary>
        /// <param name="messageSender">The message sender.</param>
        public SmsService(ITwilioMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// send as an asynchronous operation.
        /// </summary>
        /// <param name="message">The message.</param>
        public async Task SendAsync(IdentityMessage message)
        {
            await _messageSender.SendMessageAsync(message.Destination, TwilioNumber, message.Body);
        }

        #endregion Methods
    }
}