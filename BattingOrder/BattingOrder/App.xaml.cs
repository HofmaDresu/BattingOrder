using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BattingOrder
{
    public partial class App : PrismApplication
	{
        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync($"{nameof(MainPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.RegisterForNavigation<MainPage>(nameof(MainPage));
        }
    }
}
