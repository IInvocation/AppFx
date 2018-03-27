using System;
using System.Globalization;
using System.Threading.Tasks;
using FluiTec.AppFx.Mail.Configuration;
using RazorLight.Razor;

namespace FluiTec.AppFx.Mail.RazorLightProjects
{
    /// <summary>A culture aware razor light project.</summary>
    public class CultureAwareRazorLightProject : FileSystemRazorProject
    {
        /// <summary>Options for controlling the operation.</summary>
        private readonly MailServiceOptions _options;

        /// <summary>The root.</summary>
        private readonly string _root;

        /// <summary>The template key expander.</summary>
        private readonly Func<CultureInfo, string, string> _templateKeyExpander;

        /// <summary>Constructor.</summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="options">              Options for controlling the operation. </param>
        /// <param name="root">                 The root. </param>
        /// <param name="templateKeyExpander">  The template key expander. </param>
        public CultureAwareRazorLightProject(MailServiceOptions options, string root, Func<CultureInfo, string, string> templateKeyExpander) : base(root)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _root = root;
            _templateKeyExpander = templateKeyExpander ?? throw new ArgumentNullException(nameof(templateKeyExpander));
        }

        #region RazorLightProject

        /// <summary>Gets item asynchronous.</summary>
        /// <param name="templateKey">  The template key. </param>
        /// <returns>The asynchronous result that yields the item asynchronous.</returns>
        public override Task<RazorLightProjectItem> GetItemAsync(string templateKey)
        {
            if (!templateKey.EndsWith(_options.Extension))
            {
                templateKey = templateKey + _options.Extension;
            }

            var expandedKey = _templateKeyExpander(CultureInfo.CurrentUICulture, templateKey);
            return base.GetItemAsync(expandedKey);
        }

        #endregion
    }
}