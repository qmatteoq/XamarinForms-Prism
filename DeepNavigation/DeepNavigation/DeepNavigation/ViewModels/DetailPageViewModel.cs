using System;
using InfoSeries.Core.Models;
using InfoSeries.Core.Services;
using Prism.Mvvm;
using Prism.Navigation;

namespace DeepNavigation.ViewModels
{
    public class DetailPageViewModel : BindableBase, INavigationAware
    {
        private readonly ITsApiService _tsApiService;
        private SerieInfoVM _selectedShow;

        public SerieInfoVM SelectedShow
        {
            get { return _selectedShow; }
            set { SetProperty(ref _selectedShow, value); }
        }

        public DetailPageViewModel(ITsApiService tsApiService)
        {
            _tsApiService = tsApiService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            int id = Convert.ToInt32(parameters["show"]);
            SelectedShow = await _tsApiService.GetSerieById(id);
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }
    }
}
