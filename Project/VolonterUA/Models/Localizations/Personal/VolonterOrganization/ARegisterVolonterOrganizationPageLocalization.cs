using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolonterUA.Models.Localizations.Personal.VolonterOrganization
{
    public abstract class ARegisterVolonterOrganizationPageLocalization 
        : ALocalization
    {
        public abstract string NameLabel { get; }
        public abstract string NameErrorMessage { get; }
        public abstract string ToRegister { get; }
    }
}