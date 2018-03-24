using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.Identity.Resources
{
    /// <summary>An identity resource.</summary>
    [LocalizedResource]
    public class IdentityResource
    {
        /// <summary>Gets or sets the duplicate email.</summary>
        /// <value>The duplicate email.</value>
        [TranslationForCulture("Email '{0}' wird bereits verwendet.", "de")]
        public string DuplicateEmail => "Email '{0}' is already taken.";

        /// <summary>Gets or sets the name of the duplicate user.</summary>
        /// <value>The name of the duplicate user.</value>
        [TranslationForCulture("Email '{0}' wird bereits verwendet.", "de")]
        public string DuplicateUserName => "Email '{0}' is already taken.";

        /// <summary>Gets or sets the invalid email.</summary>
        /// <value>The invalid email.</value>
        [TranslationForCulture("Email '{0}' is ungültig.", "de")]
        public string InvalidEmail => "Email '{0}' is invalid.";

        /// <summary>Gets or sets the default error.</summary>
        /// <value>The default error.</value>
        [TranslationForCulture("Ein unbekannter Fehler ist aufgetreten.", "de")]
        public string DefaultError => "An unknown failure has occurred.";

        /// <summary>Gets or sets the name of the duplicate role.</summary>
        /// <value>The name of the duplicate role.</value>
        [TranslationForCulture("Die Rolle '{0}' wird bereits verwendet.", "de")]
        public string DuplicateRoleName => "Role name '{0}' is already taken.";

        /// <summary>Gets or sets the name of the invalid role.</summary>
        /// <value>The name of the invalid role.</value>
        [TranslationForCulture("Die Rolle '{0}' ist ungültig.", "de")]
        public string InvalidRoleName => "Role name '{0}' is invalid.";

        /// <summary>Gets or sets the invalid token.</summary>
        /// <value>The invalid token.</value>
        [TranslationForCulture("Ungültiger Schlüssel.", "de")]
        public string InvalidToken => "Invalid token.";

        /// <summary>Gets or sets the name of the invalid user.</summary>
        /// <value>The name of the invalid user.</value>
        [TranslationForCulture("Email '{0}' ist ungültig, kann einzig Buchstaben und Zahlen enthalten.", "de")]
        public string InvalidUserName => "Email '{0}' is invalid, can only contain letters or digits.";

        /// <summary>Gets or sets the concurrency failure.</summary>
        /// <value>The concurrency failure.</value>
        [TranslationForCulture("Parallelitäts-Fehler, das Objekt wurde zwischenzeitlich verändert.", "de")]
        public string ConcurrencyFailure => "Concurrency failure, object has been modified.";

        /// <summary>Gets or sets the login already associated.</summary>
        /// <value>The login already associated.</value>
        [TranslationForCulture("Ein Benutzer mit dieser Verknüpfung existiert bereits.", "de")]
        public string LoginAlreadyAssociated => "A user with this login already exists.";

        /// <summary>Gets or sets the password mismatch.</summary>
        /// <value>The password mismatch.</value>
        [TranslationForCulture("Falsches Passwort.", "de")]
        public string PasswordMismatch => "Incorrect password.";

        /// <summary>Gets or sets the password requires digit.</summary>
        /// <value>The password requires digit.</value>
        [TranslationForCulture("Passwort muss mindestens eine Zahl enthalten ('0'-'9').", "de")]
        public string PasswordRequiresDigit => "Passwords must have at least one digit ('0'-'9').";

        /// <summary>Gets or sets the password requires lower.</summary>
        /// <value>The password requires lower.</value>
        [TranslationForCulture("Passwort muss mindestens einen Kleinbuchstaben enthalten ('a'-'z').", "de")]
        public string PasswordRequiresLower => "Passwords must have at least one lowercase ('a'-'z').";

        /// <summary>Gets or sets the password requires non alphanumeric.</summary>
        /// <value>The password requires non alphanumeric.</value>
        [TranslationForCulture("Passwort muss mindestens ein Sonderzeichen enthalten.", "de")]
        public string PasswordRequiresNonAlphanumeric => "Passwords must have at least one non alphanumeric character.";

        /// <summary>Gets or sets the password requires upper.</summary>
        /// <value>The password requires upper.</value>
        [TranslationForCulture("Passwort muss mindestens einen Großbuchstaben enthalten ('A'-'Z').", "de")]
        public string PasswordRequiresUpper => "Passwords must have at least one uppercase ('A'-'Z').";

        /// <summary>Gets or sets the password too short.</summary>
        /// <value>The password too short.</value>
        [TranslationForCulture("Passwort muss mindestens {0} Zeichen lang sein.", "de")]
        public string PasswordTooShort => "Passwords must be at least {0} characters.";

        /// <summary>Gets or sets the user already has password.</summary>
        /// <value>The user already has password.</value>
        [TranslationForCulture("Der Benutzer hat bereits ein Passwort.", "de")]
        public string UserAlreadyHasPassword => "User already has a password set.";

        /// <summary>Gets or sets the user already in role.</summary>
        /// <value>The user already in role.</value>
        [TranslationForCulture("Benutzer bereits in der Rolle '{0}'.", "de")]
        public string UserAlreadyInRole => "User already in role '{0}'.";

        /// <summary>Gets or sets the user lockout not enabled.</summary>
        /// <value>The user lockout not enabled.</value>
        [TranslationForCulture("Aussperren ist für diesen Benutzer nicht aktiviert.", "de")]
        public string UserLockoutNotEnabled => "Lockout is not enabled for this user.";

        /// <summary>Gets or sets the user not in role.</summary>
        /// <value>The user not in role.</value>
        [TranslationForCulture("Benutzer ist nicht der Rolle '{role}'.", "de")]
        public string UserNotInRole => "User is not in role '{role}'.";
    }
}