using System.Collections.ObjectModel;
using InfoSeries.Core.Models;
using InfoSeries.Core.Services;
using Prism.Mvvm;
using Prism.Navigation;

namespace DeepNavigation.ViewModels
{
    public class UpcomingShowsPageViewModel : BindableBase, INavigationAware
    {
        private readonly ITsApiService _tsApiService;

        private ObservableCollection<SerieFollowersVM> _topSeries;

        public ObservableCollection<SerieFollowersVM> TopSeries
        {
            get { return _topSeries; }
            set { SetProperty(ref _topSeries, value); }
        }

        public UpcomingShowsPageViewModel(ITsApiService tsApiService)
        {
            _tsApiService = tsApiService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            var series = await _tsApiService.GetStatsTopSeries();
            TopSeries = new ObservableCollection<SerieFollowersVM>(series);
        }
    }
}
