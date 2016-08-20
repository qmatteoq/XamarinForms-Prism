using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using InfoSeries.Core.Models;
using InfoSeries.Core.Services;
using Xamarin.Forms;

namespace InfoSeries.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private readonly TsApiService _apiService;
        private readonly INavigationService _navigationService;
        private ObservableCollection<SerieFollowersVM> _topSeries;

        public ObservableCollection<SerieFollowersVM> TopSeries
        {
            get { return _topSeries; }
            set { SetProperty(ref _topSeries, value); }
        }

        public MainPageViewModel(TsApiService apiService, INavigationService navigationService)
        {
            _apiService = apiService;
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            var result = await _apiService.GetStatsTopSeries();
            TopSeries = new ObservableCollection<SerieFollowersVM>(result);
        }

        private Command<ItemTappedEventArgs> _goToDetailPage;

        public Command<ItemTappedEventArgs> GoToDetailPage
        {
            get
            {
                if (_goToDetailPage == null)
                {
                    _goToDetailPage = new Command<ItemTappedEventArgs>(async selected =>
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
