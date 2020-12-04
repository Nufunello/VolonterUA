using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VolonterUA.Models.Localizations.IndexPage;
using VolonterUA.Models.ViewsModels;

namespace VolonterUA.Models.ViewModels.IndexPage
{
    public class IndexPageViewModel
        : APageViewModel<AIndexPageLocalization>
    {
        public IndexPageViewModel(AIndexPageLocalization localization)
            : base(localization)
        {
        }
    }
}