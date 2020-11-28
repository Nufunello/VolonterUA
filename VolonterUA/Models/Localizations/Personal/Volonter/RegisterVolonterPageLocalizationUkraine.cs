using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolonterUA.Models.Localizations.Personal.Volonter
{
    public class RegisterVolonterPageLocalizationUkraine
        : ARegisterVolonterPageLocalization
    {
        public override string DocumentTitle => "Зарєєструвати волонтера";
        public override string PhoneNumberErrorMessage => "Номер повинен бути вигляду +380{номер оператора}... або 380{номер оператора}... або 0{номер оператора}...";
        public override string BirthdateError => "Користувач має бути повнолітнім";
        public override string LoginLabel => "Логін";
        public override string PasswordLabel => "Пароль";
        public override string FirstNameLabel => "Ім'я";
        public override string LastNameLabel => "Прізвище";
        public override string BirthdateLabel => "День народження";
        public override string PhoneNumberLabel => "Номер телефону";
        public override string ToRegister => DocumentTitle;

        protected override string FirstNameErrorMessageLength(int maxLength)
        {
            return $"Ім'я може бути до {maxLength} символів(тільки латинськими або тільки українськи буквами), у випадку якщо у вас подвійне введіть через дефіс \"-\"";
        }
        protected override string LastNameErrorMessageLength(int maxLength)
        {
            return $"Прізвище може бути до {maxLength} символів(тільки латинськими або тільки українськи буквами), у випадку якщо у вас подвійне введіть через дефіс \"-\"";
        }
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