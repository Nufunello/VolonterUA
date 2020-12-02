using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolonterUA.Models.Localizations.Personal.VolonterOrganization
{
    public class RegisterVolonterOrganizationPageLocalizationUkraine
        : ARegisterVolonterOrganizationPageLocalization
    {
        public override string NameLabel => "Ім'я організації";

        public override string NameErrorMessage => "Ім'я може бути до 30 символів(тільки латинськими або тільки українськи буквами), у випадку якщо у вас подвійне введіть через дефіс \"-\"";
        
        public override string ToRegister => "Зареєструвати організацію";

        public override string DocumentTitle => "Зареєструвати організацію";
    }
}