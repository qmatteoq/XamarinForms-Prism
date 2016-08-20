using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using InfoSeries.Core.Models;
using Prism.Navigation;

namespace InfoSeries.ViewModels
{
    public class DetailPageViewModel : BindableBase, INavigationAware
    {
        private SerieFollowersVM _selectedShow;

        public SerieFollowersVM SelectedShow
        {
            get { return _selectedShow; }
            set { SetProperty(ref _selectedShow, value); }
        }

        public DetailPageViewModel()
        {

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            SelectedShow = parameters["show"] as SerieFollowersVM;
        }
    }
}
