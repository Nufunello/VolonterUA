using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VolonterUA.Models.Localizations;
using VolonterUA.Models.Localizations.IndexPage;

namespace VolonterUA.Models.ViewsModels
{
    public abstract class APageViewModel<T> where T : ALocalization
    {
        public APageViewModel()
        { }
        protected APageViewModel(T localization)
        {
            Localization = localization;
        }
        public T Localization { get; }
    }
}