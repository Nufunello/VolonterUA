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
        public string LoginErrorMessage => LoginErrorMessageLength(8, 20);
        protected abstract string PasswordErrorMessageLength(int minLength, int maxLength);
        public string PasswordErrorMessage => PasswordErrorMessageLength(8, 20);

    }
}