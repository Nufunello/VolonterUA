using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VolonterUA.Models.Localizations.Home;
using VolonterUA.Models.Localizations.Personal.Volonter;
using VolonterUA.Models.ViewsModels;
using VolonterUA.Models.ViewValidationModels.Home;
using VolonterUA.Models.ViewValidationModels.Personal;

namespace VolonterUA.Models.ViewModels.Home
{
    public class RegisterEventPageViewModel
        : APageViewModel<ARegisterEventPageLocalization>
    {
        public RegisterEventPageViewModel()
        { }
        public RegisterEventPageViewModel(ARegisterEventPageLocalization localization) 
            : base(localization)
        {
        }
        
        public RegisterEventViewValidationModel ValidationModel { get; set; }
    }
}