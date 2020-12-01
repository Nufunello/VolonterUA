using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolonterUA.Models.Localizations.Home
{
    public abstract class AVolonterHomePageLocalization
        : ALocalization
    {
        public abstract string Location { get; }
        public abstract string Date { get; }
        public abstract string Upcoming { get; }
        public abstract string InProgress { get; }
    }
}