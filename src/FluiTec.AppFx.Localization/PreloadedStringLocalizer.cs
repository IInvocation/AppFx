using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Extensions.Localization;

namespace FluiTec.AppFx.Localization
{
    /// <summary>A preloaded string localizer.</summary>
    public class PreloadedStringLocalizer : IStringLocalizer
    {
        /// <summary>The localizations.</summary>
        private readonly Dictionary<string, LocalizedString> _localizations;

        /// <summary>Constructor.</summary>
        /// <param name="localizations">    The localizations. </param>
        public PreloadedStringLocalizer(Dictionary<string, LocalizedString> localizations)
        {
            _localizations = localizations;
        }

        /// <summary>Gets all string resources.</summary>
        /// <param name="includeParentCultures">    A <see cref="T:System.Boolean" /> indicating whether
        ///                                         to include strings from parent cultures. </param>
        /// <returns>The strings.</returns>
        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            return _localizations.Select(kv => kv.Value);
        }

        /// <summary>Creates a new <see cref="T:Microsoft.Extensions.Localization.IStringLocalizer" /> for
        /// a specific <see cref="T:System.Globalization.CultureInfo" />.</summary>
        /// <param name="culture">  The <see cref="T:System.Globalization.CultureInfo" /> to use. </param>
        /// <returns>A culture-specific
        /// <see cref="T:Microsoft.Extensions.Localization.IStringLocalizer" />.</returns>
        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets the string resource with the given name.</summary>
        /// <param name="name"> The name of the string resource. </param>
        /// <returns>The string resource as a
        /// <see cref="T:Microsoft.Extensions.Localization.LocalizedString" />.</returns>
        public LocalizedString this[string name] => _localizations[name];

        /// <summary>Gets the string resource with the given name.</summary>
        /// <param name="name">         The name of the string resource. </param>
        /// <param name="arguments">    A variable-length parameters list containing arguments. </param>
        /// <returns>The string resource as a
        /// <see cref="T:Microsoft.Extensions.Localization.LocalizedString" />.</returns>
        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var translation = this[name];
                return new LocalizedString(name, string.Format(translation.Value, arguments), translation.ResourceNotFound);
            }
        }
    }
}