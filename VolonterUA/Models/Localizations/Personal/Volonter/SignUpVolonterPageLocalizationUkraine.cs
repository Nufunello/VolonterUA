using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolonterUA.Models.Localizations.Personal.Volonter
{
    public class SignUpVolonterPageLocalizationUkraine
        : ASignUpVolonterPageLocalization
    {
        public override string DocumentTitle => "Зарєєструватися як волонтер";

        protected override string LoginErrorMessageLength(int minLength, int maxLength)
        {
            return $"Логін має складатись лише з латинських букв і мати розмір від {minLength} до {maxLength} символів";
        }

        protected override string PasswordErrorMessageLength(int minLength, int maxLength)
        {
            return $"Логін повинен складатися мінімум з {minLength} максимум {maxLength} символів та мати в собі лише і хоча б по одній: " +
            "латинські букви, цифрі та спеціальному символу";
        }
    }
}