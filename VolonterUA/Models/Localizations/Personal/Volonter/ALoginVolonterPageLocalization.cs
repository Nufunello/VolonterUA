using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolonterUA.Models.Localizations.Personal.Volonter
{
    public abstract class ALoginVolonterPageLocalization
        : ALocalization
    {
        protected string SpecialSymbols => "$&+,:;=?@#|'<>.^*()%!-";
        protected abstract string LoginErrorMessageLength(int minLength, int maxLength);
        protected abstract string PasswordErrorMessageLength(int minLength, int maxLength);

        public string LoginErrorMessage => LoginErrorMessageLength(8, 20);
        public string PasswordErrorMessage => PasswordErrorMessageLength(8, 20);
        public abstract string LoginLabel { get; }
        public abstract string PasswordLabel { get; }
    }
}