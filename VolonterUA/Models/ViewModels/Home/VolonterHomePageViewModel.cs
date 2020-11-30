using System.Collections.Generic;
using VolonterUA.Models.Database;
using VolonterUA.Models.Localizations.Home;
using VolonterUA.Models.ViewsModels;

namespace VolonterUA.Models.ViewModels.Home
{
    public class VolonterHomePageViewModel
        : APageViewModel<AVolonterHomePageLocalization>
    {
        public VolonterHomePageViewModel(AVolonterHomePageLocalization localization, IEnumerable<UpcomingVolonterEvent> upcomingVolonterEvents, IEnumerable<InProgressVolonterEvent> inProgressVolonterEvents, string fullname)
            : base(localization)
        {
            UpcomingVolonterEvents = upcomingVolonterEvents;
            InProgressVolonterEvents = inProgressVolonterEvents;
            FullName = fullname;
        }
        public IEnumerable<UpcomingVolonterEvent> UpcomingVolonterEvents { get; }
        public IEnumerable<InProgressVolonterEvent> InProgressVolonterEvents { get; }
        public string FullName { get; }
    }
}