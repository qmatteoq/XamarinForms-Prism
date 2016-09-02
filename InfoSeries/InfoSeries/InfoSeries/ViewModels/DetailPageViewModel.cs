using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using InfoSeries.Core.Models;
using InfoSeries.Services;
using Prism.Navigation;
using Xamarin.Forms;

namespace InfoSeries.ViewModels
{
    public class DetailPageViewModel : BindableBase, INavigationAware
    {
        private readonly IShareService _shareService;
        private SerieFollowersVM _selectedShow;

        public SerieFollowersVM SelectedShow
        {
            get { return _selectedShow; }
            set { SetProperty(ref _selectedShow, value); }
        }

        public DetailPageViewModel(IShareService shareService)
        {
            _shareService = shareService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            SelectedShow = parameters["show"] as SerieFollowersVM;
        }

        private DelegateCommand _shareItemCommand;

        public DelegateCommand ShareItemCommand
        {
            get
            {
                if (_shareItemCommand == null)
                {
                    _shareItemCommand = new DelegateCommand(async () =>
                    {
                        string image = SelectedShow.Images.Poster;
                        await _shareService.SharePoster(SelectedShow.Name, image);
                    });
                }

                return _shareItemCommand;
            }
        }
    }
}
