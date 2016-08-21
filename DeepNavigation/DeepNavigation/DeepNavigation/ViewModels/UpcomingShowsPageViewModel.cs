using Prism.Mvvm;
using Prism.Navigation;

namespace DeepNavigation.ViewModels
{
    public class UpcomingShowsPageViewModel : BindableBase, INavigationAware
    {
        public UpcomingShowsPageViewModel()
        {
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            //load the list of upcoming shows
        }
    }
}
