using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Contact
{
    /// <summary>An imprint resource.</summary>
    [LocalizedResource]
    public class ImprintResource
    {
        /// <summary>Gets or sets the header.</summary>
        /// <value>The header.</value>
        [TranslationForCulture("Impressum", "de")]
        public static string Header => "Imprint";

        /// <summary>Gets or sets the address header.</summary>
        /// <value>The address header.</value>
        [TranslationForCulture("Adresse", "de")]
        public static string AddressHeader => "Address";

        /// <summary>Gets or sets the address line 1.</summary>
        /// <value>The address line 1.</value>
        [TranslationForCulture("Name des Unternehmens", "de")]
        public static string AddressLine1 => "Name of the Enterprise";

        /// <summary>Gets or sets the address line 2.</summary>
        /// <value>The address line 2.</value>
        [TranslationForCulture("Zusätzliche Informationen", "de")]
        public static string AddressLine2 => "Additional info of the Enterprise";

        /// <summary>Gets or sets the address line 3.</summary>
        /// <value>The address line 3.</value>
        [TranslationForCulture("Straße", "de")]
        public static string AddressLine3 => "Street";

        /// <summary>Gets or sets the address line 4.</summary>
        /// <value>The address line 4.</value>
        [TranslationForCulture("PLZ, Stadt", "de")]
        public static string AddressLine4 => "ZipCode, City";

        /// <summary>Gets or sets the contact header.</summary>
        /// <value>The contact header.</value>
        [TranslationForCulture("Kontakt", "de")]
        public static string ContactHeader => "Contact";

        /// <summary>Gets or sets the phone label.</summary>
        /// <value>The phone label.</value>
        [TranslationForCulture("Telefon:", "de")]
        public static string PhoneLabel => "Phone:";

        /// <summary>Gets or sets the phone.</summary>
        /// <value>The phone.</value>
        [TranslationForCulture("+00 (0000) 00000 - 0", "de")]
        public static string Phone => "+00 (0000) 00000 - 0";

        /// <summary>Gets or sets the fax label.</summary>
        /// <value>The fax label.</value>
        [TranslationForCulture("Fax:", "de")]
        public static string FaxLabel => "Fax:";

        /// <summary>Gets or sets the fax.</summary>
        /// <value>The fax.</value>
        [TranslationForCulture("+00 (0000) 00000 - 0", "de")]
        public static string Fax => "+00 (0000) 00000 - 0";

        /// <summary>Gets or sets the mail label.</summary>
        /// <value>The mail label.</value>
        [TranslationForCulture("Email:", "de")]
        public static string MailLabel => "Mail:";

        /// <summary>Gets or sets the mail.</summary>
        /// <value>The mail.</value>
        [TranslationForCulture("test@testdomain.test", "de")]
        public static string Mail => "test@testdomain.test";

        /// <summary>Gets or sets the mailto mail.</summary>
        /// <value>The mailto mail.</value>
        [TranslationForCulture("mailto:test@testdomain.test", "de")]
        public static string MailtoMail => "mailto:test@testdomain.test";

        /// <summary>Gets or sets the web label.</summary>
        /// <value>The web label.</value>
        [TranslationForCulture("Internet:", "de")]
        public static string WebLabel => "Web:";

        /// <summary>Gets or sets the web.</summary>
        /// <value>The web.</value>
        [TranslationForCulture("www.testdomain.test", "de")]
        public static string Web => "www.testdomain.test";

        /// <summary>Gets or sets the web hRef.</summary>
        /// <value>The web hRef.</value>
        [TranslationForCulture("http://www.testdomain.test", "de")]
        public static string WebHref => "http://www.testdomain.test";

        /// <summary>Gets or sets the representatives header.</summary>
        /// <value>The representatives header.</value>
        [TranslationForCulture("Vertretungsberechtigte", "de")]
        public static string RepresentativesHeader => "Representatives";

        /// <summary>Gets or sets the representatives text.</summary>
        /// <value>The representatives text.</value>
        [TranslationForCulture("Name1, Name2", "de")]
        public static string RepresentativesText => "Name1, Name2";

        /// <summary>Gets or sets the legal header.</summary>
        /// <value>The legal header.</value>
        [TranslationForCulture("Legal", "de")]
        public static string LegalHeader => "Legal";

        /// <summary>Gets or sets the commercial register header.</summary>
        /// <value>The commercial register header.</value>
        [TranslationForCulture("Handelsregister:","de")]
        public static string CommercialRegisterHeader => "Commercial register:";

        /// <summary>Gets or sets the commercial register text.</summary>
        /// <value>The commercial register text.</value>
        [TranslationForCulture("HR Stadt HRA 00000", "de")]
        public static string CommercialRegisterText => "HR City HRA 00000";

        /// <summary>Gets or sets the tax identification number header.</summary>
        /// <value>The tax identification number header.</value>
        [TranslationForCulture("UST-IdNr.:", "de")]
        public static string TaxIdentificationNumberHeader => "Tax ID num.:";

        /// <summary>Gets or sets the tax identification number.</summary>
        /// <value>The tax identification number.</value>
        [TranslationForCulture("DE00000000000", "de")]
        public static string TaxIdentificationNumber => "DE00000000000";

        /// <summary>Gets or sets the tax number header.</summary>
        /// <value>The tax number header.</value>
        [TranslationForCulture("Steuer-Nr.:", "de")]
        public static string TaxNumberHeader => "Tax num.:";

        /// <summary>Gets or sets the tax number text.</summary>
        /// <value>The tax number text.</value>
        [TranslationForCulture("00/000/0000", "de")]
        public static string TaxNumberText => "00/000/0000";
    }
}