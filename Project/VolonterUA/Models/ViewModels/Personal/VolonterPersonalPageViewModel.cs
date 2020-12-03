using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VolonterUA.Models.Database;
using VolonterUA.Models.Localizations.Personal.Volonter;
using VolonterUA.Models.ViewsModels;

namespace VolonterUA.Models.ViewModels.Personal
{
    public class VolonterPersonalPageViewModel
        : APageViewModel<AVolonterPersonalPageLocalization>
    {
        public VolonterPersonalPageViewModel(AVolonterPersonalPageLocalization localization)
            : base(localization)
        { }

        public UserInfo UserInfo { get; set; }
    }
}