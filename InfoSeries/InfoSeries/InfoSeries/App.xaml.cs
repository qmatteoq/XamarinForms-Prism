using InfoSeries.Core.Services;
using Prism.Unity;
using InfoSeries.Views;
using Microsoft.Practices.Unity;
using Xamarin.Forms;
using InfoSeries.ViewModels;

namespace InfoSeries
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }
        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<DetailPage, MyCustomDetailViewModel>();
            Container.RegisterType<ITsApiService, TsApiService>();
        }
    }
}
