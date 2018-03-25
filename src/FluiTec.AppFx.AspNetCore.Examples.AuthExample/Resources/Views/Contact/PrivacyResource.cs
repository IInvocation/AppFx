using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Views.Contact
{
    /// <summary>A privacy resource.</summary>
    [LocalizedResource]
    public class PrivacyResource
    {
        /// <summary>Gets or sets the privacy header.</summary>
        /// <value>The privacy header.</value>
        [TranslationForCulture("Datenschutz", "de")]
        public static string PrivacyHeader => "Privacy";

        /// <summary>Gets or sets the data header.</summary>
        /// <value>The data header.</value>
        [TranslationForCulture("Erhebung und Verarbeitung persönlicher Daten", "de")]
        public static string DataHeader => "Collected Data";

        /// <summary>Gets or sets information describing the data.</summary>
        /// <value>Information describing the data.</value>
        [TranslationForCulture("Da der Zweck dieser Homepage der Identifizierung berechtiger Benutzer dient - werden bei der Registrierung persönliche Daten erhoben. Dies beinhaltet u.A.:", "de")]
        public static string DataDescription => "As the purpose of this homepage is the identification of entitled users - it collections personal data upon registration, this includes: ";

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [TranslationForCulture("Name", "de")]
        public static string Name => "Name";

        /// <summary>Gets or sets the mail.</summary>
        /// <value>The mail.</value>
        [TranslationForCulture("Email", "de")]
        public static string MailData => "Mail";

        /// <summary>Gets or sets the phone.</summary>
        /// <value>The phone.</value>
        [TranslationForCulture("Telefon", "de")]
        public static string Phone => "Phone";

        /// <summary>Gets or sets the usage header.</summary>
        /// <value>The usage header.</value>
        [TranslationForCulture("Nutzung und Weitergabe persönlicher Daten","de")]
        public static string UsageHeader => "Usage of personal data";

        /// <summary>Gets or sets the usage text 1.</summary>
        /// <value>The usage text 1.</value>
        [TranslationForCulture("Die gewonnenen Daten dienen im Wesentlichen der Sicherstellung der berechtigten Nutzung anderer Programme und werden nur mit Ihrer Erlaubnis an Dritte weitergegeben.", "de")]
        public static string UsageText1 => "The gained data serves the purpose of making sure you are allowed to use a certain application, thus - will be forwarded to the requested application with your consent.";

        /// <summary>Gets or sets the usage text 2.</summary>
        /// <value>The usage text 2.</value>
        [TranslationForCulture("Die Weitergabe solcher Daten erfolgt i.d.R. im Rahmen der OpenId-Connect-Schnittstelle, bei der andere Programme ohne weitere Registrierung Ihre Benutzerdaten erhalten.", "de")]
        public static string UsageText2 => "The data is forwared using the OpenId-Connect interface, allowing the application to gain access to your personal data.";

        /// <summary>Gets or sets the right to information header.</summary>
        /// <value>The right to information header.</value>
        [TranslationForCulture("Auskunftsrecht", "de")]
        public static string RightToInformationHeader => "Right to information";

        /// <summary>Gets or sets the right to information text.</summary>
        /// <value>The right to information text.</value>
        [TranslationForCulture("Auf Anforderung teilen wir Ihnen schriftlich entsprechend dem geltenden Recht mit ob und welche persönlichen Daten über Sie bei uns gespeichert sind.", "de")]
        public static string RightToInformationText => "Upon request of yourself, we'll inform you - according to the legal right wether and which personal data is saved about you.";

        /// <summary>Gets or sets the safety header.</summary>
        /// <value>The safety header.</value>
        [TranslationForCulture("Sicherheit", "de")]
        public static string SafetyHeader => "Safety";

        /// <summary>Gets or sets the safety text.</summary>
        /// <value>The safety text.</value>
        [TranslationForCulture("Wir setzen technische und organisatorische Sicherungsmaßnahmen ein, um die zur Verfügung gestellten Daten vor zufälligen oder beabsichtigten Manipulationen, Verlust, Zerstörung oder unberechtigten Zugriff zu schützen. Unsere Sicherheitsmaßnahmen werden entsprechend der technologischen Entwicklung fortlaufend verbessert.", "de")]
        public static string SafetyText => "Wir use techninal and organizational measuress in order to protect the saved data from random or intended manipulation, loss, destruction or unauthorized access. These measures are improved according to the technical development.";

        /// <summary>Gets or sets the cookies header.</summary>
        /// <value>The cookies header.</value>
        [TranslationForCulture("Cookies", "de")]
        public static string CookiesHeader => "Cookies";

        /// <summary>Gets or sets the cookies text 1.</summary>
        /// <value>The cookies text 1.</value>
        [TranslationForCulture("Diese Homepage setzt Cookies und erfüllt die Hinweispflicht auf den Einsatz dieser.", "de")]
        public static string CookiesText1 => "This application uses cookies and informs accordingly.";

        /// <summary>Gets or sets the cookies text 2.</summary>
        /// <value>The cookies text 2.</value>
        [TranslationForCulture("Die hier eingesetzten Cookies, dienen der Nutzungsfreundlichkeit und der Sicherheit Ihrer Daten.", "de")]
        public static string CookiesText2 => "The used cookies serve the usability of the application and safety of your data.";

        /// <summary>Gets or sets the cookies text 3.</summary>
        /// <value>The cookies text 3.</value>
        [TranslationForCulture("Cookies sind kleine Textdateien, die wir an Sie - und Sie umgekehrt an uns senden und enthalten Daten, die es uns ermöglichen uns zu erkennen, dass Sie bereits angemeldet sind und über welche Rechte Sie auf der Seite verfügen.", "de")]
        public static string CookiesText3 => "Cookies are small textfiles, which your browser - and our server send to each other, enabling us to know you're logged in and which rights are associated with your account.";

        /// <summary>Gets or sets the limitation of liability.</summary>
        /// <value>The limitation of liability.</value>
        [TranslationForCulture("Haftungsbeschränkung", "de")]
        public static string LimitationOfLiability => "Limitation of liability";

        /// <summary>The first liability text.</summary>
        [TranslationForCulture("Die Inhalte des Internetauftritts wurden mit größtmöglicher Sorgfalt und nach bestem Gewissen erstellt. Dennoch übernimmt der Anbieter dieser Webseite keine Gewähr für die Aktualität, Vollständigkeit und Richtigkeit der bereitgestellten Seiten und Inhalte.", "de")]
        public static string LiabilityText1 = "The content of this application was composed with utmost care and remorse conscience. However - we are not liable for currentness of data, completeness or accuracy of the content.";

        /// <summary>The second liability text.</summary>
        [TranslationForCulture("Als Diensteanbieter ist der Anbieter dieser Webseite gemäß § 7 Abs. 1 TMG für eigene Inhalte und bereitgestellte Informationen auf diesen Seiten nach den allgemeinen Gesetzen verantwortlich; nach den §§ 8 bis 10 TMG jedoch nicht verpflichtet, die übermittelten oder gespeicherten fremden Informationen zu überwachen. Eine Entfernung oder Sperrung dieser Inhalte erfolgt umgehend ab dem Zeitpunkt der Kenntnis einer konkreten Rechtsverletzung. Eine Haftung ist erst ab dem Zeitpunkt der Kenntniserlangung möglich.", "de")]
        public static string LiabilityText2 = "As the service-provider, according to §7 Abs. 1 TMG, we are responsible for the published information in respect of law; according to §8 to 10 TNG however - we are not obligated to supervise given external data. Removal or suspension of such content, will be carried out on the spot upon knowledge of a concrete encroachment. Accountablility is only possible after knowledge of such.";

        /// <summary>Gets or sets the external links header.</summary>
        /// <value>The external links header.</value>
        [TranslationForCulture("Externe Links", "de")]
        public static string ExternalLinksHeader => "External links";

        /// <summary>Gets or sets the external links text.</summary>
        /// <value>The external links text.</value>
        [TranslationForCulture("Die Webseite enthält „externe Links“ (Verlinkungen) zu anderen Webseiten, auf deren Inhalt der Anbieter der Webseite keinen Einfluss hat. Aus diesem Grund kann der Anbieter für diese Inhalte auch keine Gewähr übernehmen. Für die Inhalte und Richtigkeit der bereitgestellten Informationen ist der jeweilige Anbieter der verlinkten Webseite verantwortlich. Zum Zeitpunkt der Verlinkung waren keine Rechtsverstöße erkennbar. Bei Bekanntwerden einer solchen Rechtsverletzung wird der Link umgehend entfernen.", "de")]
        public static string ExternalLinksText => "The application contains external links to other homepages, whose content we can not influence. Because of that - we are not liable for that content. The owner of these homepages is responsible for the content and accuracy of his homepage. As of the time of creation of that link - we could not see any encroachment. Upon knowledge of that of such encroachment - we'll remove such links.";

        /// <summary>Gets or sets the copy right header.</summary>
        /// <value>The copy right header.</value>
        [TranslationForCulture("Urheberrecht/Leistungsschutzrecht", "de")]
        public static string CopyRightHeader => "Copyright";

        /// <summary>Gets or sets the copy right text.</summary>
        /// <value>The copy right text.</value>
        [TranslationForCulture("Die auf dieser Webseite veröffentlichten Inhalte, Werke und bereitgestellten Informationen unterliegen dem deutschen Urheberrecht und Leistungsschutzrecht. Jede Art der Vervielfältigung, Bearbeitung, Verbreitung, Einspeicherung und jede Art der Verwertung außerhalb der Grenzen des Urheberrechts bedarf der vorherigen schriftlichen Zustimmung des jeweiligen Rechteinhabers. Das unerlaubte Kopieren/Speichern der bereitgestellten Informationen auf diesen Webseiten ist nicht gestattet und strafbar.", "de")]
        public static string CopyRightText => "The published content is subject to the german copy right. Any kind of duplication, editing, distribution, retention and every kind of utilization apart from the copyright law requires prior, written agreement of the owner. Unauthorized copying of the published content is not allowed and accusable.";

        /// <summary>Gets or sets the security administrator header.</summary>
        /// <value>The security administrator header.</value>
        [TranslationForCulture("Datenschutzbeauftragter", "de")]
        public static string SecurityAdministratorHeader => "Datenschutzbeauftragter";

        /// <summary>Gets or sets the security administrator text.</summary>
        /// <value>The security administrator text.</value>
        [TranslationForCulture("Wenn Sie Fragen hinsichtlich der Verarbeitung Ihrer persönlicher Daten haben, können Sie sich direkt an unseren Beauftragten für den Datenschutz wenden, der auch im Falle von Auskunftsersuchen, Anträgen oder Beschwerden zur Verfügung steht:", "de")]
        public static string SecurityAdministratorText => "If you have questions about the usage of your data - you can contact our administrator, who's also available for information requests, proposals and complaints.";

        /// <summary>Gets or sets the address line 1.</summary>
        /// <value>The address line 1.</value>
        [TranslationForCulture("Datenschutzbeauftragter", "de")]
        public static string AddressLine1 => "Security administrator";

        /// <summary>Gets or sets the address line 2.</summary>
        /// <value>The address line 2.</value>
        [TranslationForCulture("Firmenname", "de")]
        public static string AddressLine2 => "Enterprise name";

        /// <summary>Gets or sets the address line 3.</summary>
        /// <value>The address line 3.</value>
        [TranslationForCulture("Straße", "de")]
        public static string AddressLine3 => "Street";

        /// <summary>Gets or sets the address line 4.</summary>
        /// <value>The address line 4.</value>
        [TranslationForCulture("PLZ, Ort", "de")]
        public static string AddressLine4 => "ZipCode, City";

        /// <summary>Gets or sets the mail label.</summary>
        /// <value>The mail label.</value>
        [TranslationForCulture("Email:", "de")]
        public static string MailLabel => "Mail:";

        /// <summary>Gets or sets the mailto.</summary>
        /// <value>The mailto.</value>
        [TranslationForCulture("mailto:test@testdomain.test", "de")]
        public static string Mailto => "mailto:test@testdomain.test";

        /// <summary>Gets or sets the mail.</summary>
        /// <value>The mail.</value>
        [TranslationForCulture("test@testdomain.test", "de")]
        public static string Mail => "test@testdomain.test";
    }
}