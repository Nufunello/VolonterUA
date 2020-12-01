using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolonterUA.Models.Localizations.Home
{
    public class VolonterHomePageLocalizationUkraine
        : AVolonterHomePageLocalization
    {
        public override string DocumentTitle => "Домашня сторінка";

        public override string Location => "Локація";

        public override string Upcoming => "Заплановані";

        public override string InProgress => "Зараз відбуваються";

        public override string Date => "Дата";
    }
}