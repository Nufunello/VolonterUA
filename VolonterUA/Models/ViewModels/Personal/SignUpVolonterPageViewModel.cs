using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VolonterUA.Models.Localizations.Personal.Volonter;
using VolonterUA.Models.ViewsModels;
using VolonterUA.Models.ViewValidationModels.Personal;

namespace VolonterUA.Models.ViewModels.Personal
{
    public class SignUpVolonterPageViewModel
        : APageViewModel<ASignUpVolonterPageLocalization>
    {
        public SignUpVolonterPageViewModel(ASignUpVolonterPageLocalization localization) 
            : base(localization)
        {
        }

        public SignUpVolonterViewValidationModel ValidationModel { get; }
    }
}