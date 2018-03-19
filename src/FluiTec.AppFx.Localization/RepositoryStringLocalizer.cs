using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Extensions.Localization;

namespace FluiTec.AppFx.Localization
{
    /// <summary>A repository string localizer.</summary>
    public class RepositoryStringLocalizer : IStringLocalizer
    {
        /// <summary>The cache.</summary>
        private readonly RepositoryStringCache _cache;

        /// <summary>Constructor.</summary>
        /// <param name="cache">    The cache. </param>
        public RepositoryStringLocalizer(RepositoryStringCache cache)
        {
            _cache = cache;
        }

        /// <summary>Gets all string resources.</summary>
        /// <param name="includeParentCultures">    A <see cref="T:System.Boolean" /> indicating whether
        ///                                         to include strings from parent cultures. </param>
        /// <returns>The strings.</returns>
        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            return _cache.GetTranslations(CultureInfo.CurrentUICulture.Name)
                .Select(kv => new LocalizedString(kv.Key, kv.Value));
        }

        /// <summary>Creates a new <see cref="T:Microsoft.Extensions.Localization.IStringLocalizer" /> for
        /// a specific <see cref="T:System.Globalization.CultureInfo" />.</summary>
        /// <param name="culture">  The <see cref="T:System.Globalization.CultureInfo" /> to use. </param>
        /// <returns>A culture-specific
        /// <see cref="T:Microsoft.Extensions.Localization.IStringLocalizer" />.</returns>
        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            var translations = _cache.GetTranslations(culture.Name);
            var localizedStrings = translations
                .Select(t => new LocalizedString(t.Key, t.Value ?? t.Key, t.Value == null))
                .ToDictionary(l => l.Name, l => l);
            return new PreloadedStringLocalizer(localizedStrings);
        }

        /// <summary>Gets the string resource with the given name.</summary>
        /// <param name="name"> The name of the string resource. </param>
        /// <returns>The string resource as a
        /// <see cref="T:Microsoft.Extensions.Localization.LocalizedString" />.</returns>
        public LocalizedString this[string name]
        {
            get
            {
                var value = _cache.GetTranslation(CultureInfo.CurrentUICulture.Name, name);
                return new LocalizedString(name, value ?? name, value == null);
            }
        }

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