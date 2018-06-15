using BattingOrder.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BattingOrder
{
    public partial class App : PrismApplication
	{
        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync($"{nameof(NavPage)}/{nameof(MainPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.RegisterForNavigation<NavPage>(nameof(NavPage));
            containerRegistry.RegisterForNavigation<MainPage>(nameof(MainPage));
        }
    }
}
