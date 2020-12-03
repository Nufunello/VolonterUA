using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VolonterUA.Models.Localizations.Personal.VolonterOrganization;
using VolonterUA.Models.ViewsModels;
using VolonterUA.Models.ViewValidationModels.Personal;

namespace VolonterUA.Models.ViewModels.Personal
{
    public class RegisterVolonterOrganizationPageViewModel
        : APageViewModel<ARegisterVolonterOrganizationPageLocalization>
    {
        public RegisterVolonterOrganizationPageViewModel()
        { }
        public RegisterVolonterOrganizationPageViewModel(ARegisterVolonterOrganizationPageLocalization localization)
            : base(localization)
        {

        }
        public RegisterVolonterOrganizationViewValidationModel ValidationModel { get; set; }
    }
}