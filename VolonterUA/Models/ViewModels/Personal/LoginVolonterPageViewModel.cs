using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VolonterUA.Models.Localizations.Personal.Volonter;
using VolonterUA.Models.ViewsModels;
using VolonterUA.Models.ViewValidationModels.Personal;

namespace VolonterUA.Models.ViewModels.Personal
{
    public class LoginVolonterPageViewModel
        : APageViewModel<ALoginVolonterPageLocalization>
    {
        public LoginVolonterPageViewModel()
        { }
        public LoginVolonterPageViewModel(ALoginVolonterPageLocalization localization) 
            : base(localization)
        {
        }

        public LoginVolonterViewValidationModel ValidationModel { get; set; }
    }
}