using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using InfoSeries.Core.Models;
using InfoSeries.Core.Services;
using Xamarin.Forms;

namespace InfoSeries.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private readonly ITsApiService _apiService;
        private readonly INavigationService _navigationService;

        private ObservableCollection<SerieFollowersVM> _topSeries;

        public ObservableCollection<SerieFollowersVM> TopSeries
        {
            get { return _topSeries; }
            set { SetProperty(ref _topSeries, value); }
        }

        public MainPageViewModel(ITsApiService apiService, INavigationService navigationService)
        {
            _apiService = apiService;
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (TopSeries == null || TopSeries.Count == 0)
            {
                var result = await _apiService.GetStatsTopSeries();
                TopSeries = new ObservableCollection<SerieFollowersVM>(result);
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        private DelegateCommand<ItemTappedEventArgs> _goToDetailPage;

        public DelegateCommand<ItemTappedEventArgs> GoToDetailPage
        {
            get
            {
                if (_goToDetailPage == null)
                {
                    _goToDetailPage = new DelegateCommand<ItemTappedEventArgs>(async selected =>
                    {
                        NavigationParameters param = new NavigationParameters();
                        param.Add("show", selected.Item);
                        await _navigationService.NavigateAsync("DetailPage", param);
                    });
                }

                return _goToDetailPage;
            }
        }
    }
}
