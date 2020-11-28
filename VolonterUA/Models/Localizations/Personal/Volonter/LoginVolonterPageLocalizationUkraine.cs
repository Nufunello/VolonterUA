using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolonterUA.Models.Localizations.Personal.Volonter
{
    public class LoginVolonterPageLocalizationUkraine
        : ALoginVolonterPageLocalization
    {
        public override string LoginLabel => "Логін";
        public override string PasswordLabel => "Пароль";

        public override string DocumentTitle => "Увійти";

        protected override string LoginErrorMessageLength(int minLength, int maxLength)
        {
            return $"Логін має складатись лише з латинських букв і мати розмір від {minLength} до {maxLength} символів";
        }
        protected override string PasswordErrorMessageLength(int minLength, int maxLength)
        {
            return $"Пароль повинен складатися мінімум з {minLength} максимум {maxLength} символів та мати в собі лише і хоча б по одній: " +
            $"латинські букви(велика та маленька), цифрі та спеціальному символу({SpecialSymbols})";
        }
    }
}