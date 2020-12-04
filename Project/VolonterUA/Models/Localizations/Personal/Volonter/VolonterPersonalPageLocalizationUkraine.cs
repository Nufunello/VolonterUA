using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolonterUA.Models.Localizations.Personal.Volonter
{
    public class VolonterPersonalPageLocalizationUkraine
        : AVolonterPersonalPageLocalization
    {
        public override string Location => "Локація";

        public override string Date => "Дата";

        public override string FirstName => "Ім'я";
        public override string LastName => "Прізвище";

        public override string Subscribes => "Очікую";

        public override string PhoneNumber => "Номер телефону";

        public override string Years => "Повних років";

        public override string RepresentativeOf => "Представник";

        public override string OrganizedCount(int count)
        {
            return $"Організував {count} {GetNumberSuffix(count)} заходів";
        }
        public override string Karma => "Рівень доброти";

        public override string DocumentTitle => "Особистий кабінет";
        private string GetNumberSuffix(int count)
        {
            if (count > 10 && count < 20)
            {
                return "разів";
            }
            else
            {
                int lastdigit = count % 10;
                switch (lastdigit)
                {
                    case 1:
                        return "раз";
                    case 2:
                    case 3:
                    case 4:
                        return "рази";
                    default:
                        return "разів";
                }
            }
        }
        public override string Volontered(int count)
        {
            return $"Був волонтером {count} {GetNumberSuffix(count)}";
        }
    }
}