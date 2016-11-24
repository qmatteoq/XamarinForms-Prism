using Prism.Commands;
using Prism.Mvvm;
using InfoSeries.Core.Models;
using InfoSeries.Services;
using Prism.Navigation;

namespace InfoSeries.ViewModels
{
    public class MyCustomDetailViewModel : BindableBase, INavigationAware
    {
        private readonly IShareService _shareService;
        private SerieFollowersVM _selectedShow;

        public SerieFollowersVM SelectedShow
        {
            get { return _selectedShow; }
            set { SetProperty(ref _selectedShow, value); }
        }

        public MyCustomDetailViewModel(IShareService shareService)
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

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        private DelegateCommand _shareItemCommand;

        public DelegateCommand ShareItemCommand
        {
            get
            {
                if (_shareItemCommand == null)
                {
                    _shareItemCommand = new DelegateCommand(() =>
                    {
                        _shareService.Share(SelectedShow.Name, SelectedShow.Overview);
                    });
                }

                return _shareItemCommand;
            }
        }
    }
}
