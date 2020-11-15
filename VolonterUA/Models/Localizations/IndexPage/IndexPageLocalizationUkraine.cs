using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolonterUA.Models.Localizations.IndexPage
{
    public class IndexPageLocalizationUkraine
        : AIndexPageLocalization
    {
        public override string DocumentTitle => "Волонтер Україна";
        public override string Title => "Допоможи світу - допоможи собі";
        public override string Slogan => "Наша ціль - довести, що основою суспільства є взаємодопомога, яка приведе нас до моральних та інтелектуальних висот";
        public override string WantToHelp => "Хочу допомогти";
        public override string SearchForVolonters => "Шукаю волонтерів";
    }
}