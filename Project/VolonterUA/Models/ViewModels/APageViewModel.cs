using VolonterUA.Models.Localizations;

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