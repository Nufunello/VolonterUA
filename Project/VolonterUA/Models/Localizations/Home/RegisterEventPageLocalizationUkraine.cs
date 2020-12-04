using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolonterUA.Models.Localizations.Home
{
    public class RegisterEventPageLocalizationUkraine
        : ARegisterEventPageLocalization
    {
        public override string DocumentTitle => "Організувати захід";

        public override string TitleLabel => "Назва волонтерського заходу";

        public override string TextDescriptionLabel => "Опис";

        public override string DateLabel => "Дата";

        public override string TextAddressLabel => "Адресса";

        public override string ToRegister => "Організувати";

        public override string ErrorMessage => "Поле не може бути пустим";
    }
}