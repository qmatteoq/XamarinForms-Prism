using Prism.Mvvm;

namespace DeepNavigation.ViewModels
{
    public class UpcomingShowsPageViewModel : BindableBase
    {
        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public UpcomingShowsPageViewModel()
        {
            Description = "This is the list of upcoming shows";
        }
    }
}
