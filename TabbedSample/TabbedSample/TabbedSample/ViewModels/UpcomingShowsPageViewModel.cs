using System;
using Prism;
using Prism.Mvvm;
using InfoSeries.Core.Models;
using System.Collections.ObjectModel;
using InfoSeries.Core.Services;

namespace TabbedSample.ViewModels
{
    public class UpcomingShowsPageViewModel : BindableBase, IActiveAware
    {
        private ITsApiService _tsApiService;

        public UpcomingShowsPageViewModel(ITsApiService tsApiService)
        {
            _tsApiService = tsApiService;
        }

        public event EventHandler IsActiveChanged;

        private ObservableCollection<SerieFollowersVM> _topSeries;

        public ObservableCollection<SerieFollowersVM> TopSeries
        {
            get { return _topSeries; }
            set { SetProperty(ref _topSeries, value); }
        }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                OnActiveTabChangedAsync();
            }
        }

        private async void OnActiveTabChangedAsync()
        {
            if (IsActive)
            {
                var series = await _tsApiService.GetStatsTopSeries();
                TopSeries = new ObservableCollection<SerieFollowersVM>(series);
            }
        }
    }
}
