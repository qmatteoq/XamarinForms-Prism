using System.Collections.ObjectModel;
using InfoSeries.Core.Models;
using InfoSeries.Core.Services;
using Prism.Mvvm;
using Prism.Navigation;
using Prism;
using System;

namespace TabbedSample.ViewModels
{
    public class ShowsListPageViewModel : BindableBase, IActiveAware
    {
        private readonly ITsApiService _tsApiService;

        private ObservableCollection<SerieFollowersVM> _highlightSeries;

        public ObservableCollection<SerieFollowersVM> HighlightSeries
        {
            get { return _highlightSeries; }
            set { SetProperty(ref _highlightSeries, value); }
        }


        public ShowsListPageViewModel(ITsApiService tsApiService)
        {
            _tsApiService = tsApiService;
        }

        public event EventHandler IsActiveChanged;

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
                HighlightSeries = new ObservableCollection<SerieFollowersVM>(series);
            }
        }
    }
}
