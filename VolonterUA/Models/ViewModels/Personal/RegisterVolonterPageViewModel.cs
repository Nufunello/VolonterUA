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
    public class RegisterVolonterPageViewModel
        : APageViewModel<ARegisterVolonterPageLocalization>
    {
        public RegisterVolonterPageViewModel()
        { }
        public RegisterVolonterPageViewModel(ARegisterVolonterPageLocalization localization) 
            : base(localization)
        {
        }

        public RegisterVolonterViewValidationModel ValidationModel { get; set; }
    }
}