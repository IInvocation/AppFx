using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Shared
{
    [LocalizedResource]
    public class FooterResource
    {
        /// <summary>Gets or sets the imprint.</summary>
        /// <value>The imprint.</value>
        [TranslationForCulture("Impressum", "de")]
        public static string Imprint => "Imprint";

        /// <summary>Gets or sets the privacy.</summary>
        /// <value>The privacy.</value>
        [TranslationForCulture("Datenschutz", "de")]
        public static string Privacy => "Privacy";

        /// <summary>Gets or sets the terms of use.</summary>
        /// <value>The terms of use.</value>
        [TranslationForCulture("Nutzungsbedingungen", "de")]
        public static string TermsOfUse => "Terms of use";
    }
}