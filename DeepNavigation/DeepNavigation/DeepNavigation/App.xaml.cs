using DeepNavigation.Views;
using Prism.Unity;
using Xamarin.Forms;

namespace DeepNavigation
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("MainTabbedPage/NavigationPage/ShowsListPage/DetailPage?id=1");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<UpcomingShowsPage>();
            Container.RegisterTypeForNavigation<ShowsListPage>();
            Container.RegisterTypeForNavigation<DetailPage>();
            Container.RegisterTypeForNavigation<MainTabbedPage>();
            Container.RegisterTypeForNavigation<NavigationPage>();
        }
    }
}
