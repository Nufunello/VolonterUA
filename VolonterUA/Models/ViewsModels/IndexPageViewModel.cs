using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VolonterUA.Models.Localizations.IndexPage;

namespace VolonterUA.Models.ViewsModels
{
    public class IndexPageViewModel
    {
        public IndexPageViewModel(AIndexPageLocalization localization)
        {
            Localization = localization;
        }
        public AIndexPageLocalization Localization { get; }
    }
}