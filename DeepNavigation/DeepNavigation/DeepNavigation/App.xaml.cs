using DeepNavigation.Views;
using InfoSeries.Core.Services;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;

namespace DeepNavigation
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("MainTabbedPage/NavigationPage/ShowsListPage/DetailPage?show=279121");
            //await NavigationService.NavigateAsync("MainTabbedPage/NavigationPage/ShowsListPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<UpcomingShowsPage>();
            Container.RegisterTypeForNavigation<ShowsListPage>();
            Container.RegisterTypeForNavigation<DetailPage>();
            Container.RegisterTypeForNavigation<MainTabbedPage>();
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterType<ITsApiService, TsApiService>();
        }
    }
}
