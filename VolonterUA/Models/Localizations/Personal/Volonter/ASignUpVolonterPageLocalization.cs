using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolonterUA.Models.Localizations.Personal.Volonter
{
    public abstract class ASignUpVolonterPageLocalization
        : ALocalization
    {
        protected abstract string LoginErrorMessageLength(int minLength, int maxLength);
        protected abstract string PasswordErrorMessageLength(int minLength, int maxLength);
        protected abstract string FirstNameErrorMessageLength(int maxLength);
        protected abstract string LastNameErrorMessageLength(int maxLength);

        public string LoginErrorMessage => LoginErrorMessageLength(8, 20);
        public string PasswordErrorMessage => PasswordErrorMessageLength(8, 20);
        public string FirstNameErrorMessage => FirstNameErrorMessageLength(30);
        public string LastNameErrorMessage => LastNameErrorMessageLength(30);
        public abstract string PhoneNumberErrorMessage { get; }
    }
}