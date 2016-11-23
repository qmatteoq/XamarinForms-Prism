using InfoSeries.Core.Services;
using Prism.Unity;
using Microsoft.Practices.Unity;
using TabbedSample.Views;

namespace TabbedSample
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("MainTabbedPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainTabbedPage>();
            Container.RegisterTypeForNavigation<ShowsListPage>();
            Container.RegisterTypeForNavigation<UpcomingShowsPage>();
            Container.RegisterType<ITsApiService, TsApiService>();
        }
    }
}
