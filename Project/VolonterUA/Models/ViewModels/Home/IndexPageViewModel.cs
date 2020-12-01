using VolonterUA.Models.Localizations.Home;
using VolonterUA.Models.ViewsModels;

namespace VolonterUA.Models.ViewModels.Home
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