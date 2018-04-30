using System;
using FluiTec.AppFx.Mail.Configuration;
using RazorLight;

namespace FluiTec.AppFx.Mail
{
    /// <summary>	A mail kit templating mail service. </summary>
    public class MailKitRazorLightTemplatingMailService : MailKitTemplatingMailService
    {
        #region Constructors

        /// <summary>	Constructor. </summary>
        /// <param name="engine"> 	The engine. </param>
        /// <param name="options">	Options for controlling the operation. </param>
        public MailKitRazorLightTemplatingMailService(IRazorLightEngine engine, MailServiceOptions options)
            : base(new RazorLightTemplatingService(engine), options)
        {
        }

        /// <summary>	Constructor. </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are
        ///     null.
        /// </exception>
        /// <param name="viewPath">	Full pathname of the view file. </param>
        /// <param name="options"> 	Options for controlling the operation. </param>
        public MailKitRazorLightTemplatingMailService(string viewPath, MailServiceOptions options)
            : base(new RazorLightTemplatingService(viewPath), options)
        {
        }

        #endregion
    }
}