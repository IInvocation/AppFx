using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FluiTec.AppFx.Mail.Configuration;
using FluiTec.AppFx.Mail.LocationExpanders;
using RazorLight.Razor;

namespace FluiTec.AppFx.Mail.RazorLightProjects
{
    /// <summary>A location expanding razor project.</summary>
    public class LocationExpandingRazorProject : FileSystemRazorProject
    {
        #region Constructors

        /// <summary>Constructor.</summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are
        ///     null.
        /// </exception>
        /// <param name="options">      Options for controlling the operation. </param>
        /// <param name="root">         The root. </param>
        /// <param name="expanders">    The expanders. </param>
        public LocationExpandingRazorProject(MailServiceOptions options, string root,
            IEnumerable<ILocationExpander> expanders) : base(root)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _root = root;
            _expanders = expanders ?? throw new ArgumentNullException(nameof(expanders));
        }

        #endregion

        #region FileSystemRazorProject

        /// <summary>Gets item asynchronous.</summary>
        /// <param name="templateKey">  The template key. </param>
        /// <returns>The asynchronous result that yields the item asynchronous.</returns>
        public override Task<RazorLightProjectItem> GetItemAsync(string templateKey)
        {
            foreach (var expander in _expanders)
            foreach (var location in expander.Expand(templateKey))
            {
                var absolutePath = NormalizeKey(location);
                if (File.Exists(absolutePath))
                    return Task.FromResult(
                        (RazorLightProjectItem) new FileSystemRazorProjectItem(location,
                            new FileInfo(absolutePath)));
            }

            // let the base-class try it's best and throw...
            return base.GetItemAsync(templateKey);
        }

        #endregion

        #region Fields

        /// <summary>Options for controlling the operation.</summary>
        private readonly MailServiceOptions _options;

        /// <summary>The root.</summary>
        private readonly string _root;

        /// <summary>The expanders.</summary>
        private readonly IEnumerable<ILocationExpander> _expanders;

        #endregion
    }
}