using System.Collections.ObjectModel;
using InfoSeries.Core.Models;
using InfoSeries.Core.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace DeepNavigation.ViewModels
{
    public class ShowsListPageViewModel : BindableBase, INavigationAware
    {
        private readonly ITsApiService _tsApiService;
        private readonly INavigationService _navigationService;
        private ObservableCollection<SerieFollowersVM> _highlightSeries;

        public ObservableCollection<SerieFollowersVM> HighlightSeries
        {
            get { return _highlightSeries; }
            set { SetProperty(ref _highlightSeries, value); }
        }


        public ShowsListPageViewModel(ITsApiService tsApiService, INavigationService navigationService)
        {
            _tsApiService = tsApiService;
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            var series = await _tsApiService.GetStatsTopSeries();
            HighlightSeries = new ObservableCollection<SerieFollowersVM>(series);
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
                        var serie = selected.Item as SerieFollowersVM;
                        param.Add("show", serie.Id);
                        await _navigationService.NavigateAsync("DetailPage", param);
                    });
                }

                return _goToDetailPage;
            }
        }
    }
}
