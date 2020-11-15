using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolonterUA.Models.Localizations.IndexPage
{
    public abstract class AIndexPageLocalization
    {
        public abstract string Title { get; }
        public abstract string Slogan { get; }
        public abstract string WantToHelp { get; }
        public abstract string SearchForVolonters { get; }
    }
}
