using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolonterUA.Models.Localizations.Personal.Volonter
{
    public abstract class AVolonterPersonalPageLocalization
        : ALocalization
    {
        public abstract string Location { get; }
        public abstract string Date { get; }
        public abstract string FirstName { get; }
        public abstract string LastName { get; }
        public abstract string Subscribes { get; }
        public abstract string PhoneNumber { get; }
        public abstract string Years { get; }
        public abstract string RepresentativeOf { get; }
        public abstract string OrganizedCount(int count);
        public abstract string Volontered(int count);
        public abstract string Karma { get; }
    }
}