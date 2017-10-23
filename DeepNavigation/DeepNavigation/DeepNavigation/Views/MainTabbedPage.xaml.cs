using Prism.Common;
using Prism.Navigation;
using Xamarin.Forms;

namespace DeepNavigation.Views
{
    public partial class MainTabbedPage : TabbedPage, INavigationAware
    {
        public MainTabbedPage()
        {
            InitializeComponent();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            foreach (var child in Children)
            {
                PageUtilities.OnNavigatedTo(child, parameters);
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }
    }
}
