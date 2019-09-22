// ***********************************************************************
// Assembly         : AdminLTE.NET.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="TwilioMessageSender.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.DataAccess.Helpers
{
    using System.Configuration;
    using System.Threading.Tasks;

    using AdminLTE.NET.DataAccess.Interfaces;

    using Twilio;
    using Twilio.Rest.Api.V2010.Account;
    using Twilio.Types;

    /// <summary>
    /// Class TwilioMessageSender.
    /// Implements the <see cref="AdminLTE.NET.DataAccess.Interfaces.ITwilioMessageSender" />
    /// </summary>
    /// <seealso cref="AdminLTE.NET.DataAccess.Interfaces.ITwilioMessageSender" />
    public class TwilioMessageSender : ITwilioMessageSender
    {
        #region Fields

        /// <summary>
        /// The account sid
        /// </summary>
        private readonly string AccountSid = ConfigurationManager.AppSettings["AccountSid"] ?? "ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
        /// <summary>
        /// The authentication token
        /// </summary>
        private readonly string AuthToken = ConfigurationManager.AppSettings["AuthToken"] ?? "aXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TwilioMessageSender"/> class.
        /// </summary>
        public TwilioMessageSender()
        {
            TwilioClient.Init(AccountSid, AuthToken);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// send message as an asynchronous operation.
        /// </summary>
        /// <param name="to">To.</param>
        /// <param name="from">From.</param>
        /// <param name="body">The body.</param>
        public async Task SendMessageAsync(string to, string from, string body)
        {
            await MessageResource.CreateAsync(new PhoneNumber(to),
                                              from: new PhoneNumber(from),
                                              body: body);
        }

        #endregion Methods
    }
}