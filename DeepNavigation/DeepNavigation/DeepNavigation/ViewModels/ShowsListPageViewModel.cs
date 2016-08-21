using Prism.Mvvm;
using Prism.Navigation;

namespace DeepNavigation.ViewModels
{
    public class ShowsListPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ShowsListPageViewModel()
        {
           
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Title = "List of shows";
        }
    }
}
