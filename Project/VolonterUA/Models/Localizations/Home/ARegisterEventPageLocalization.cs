using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolonterUA.Models.Localizations.Home
{
    public abstract class ARegisterEventPageLocalization
        : ALocalization
    {
        public abstract string TitleLabel { get; }
        public abstract string TextDescriptionLabel { get; }
        public abstract string DateLabel { get; }
        public abstract string TextAddressLabel { get; }
        public abstract string ErrorMessage { get; }
        public abstract string ToRegister { get; }
    }
}