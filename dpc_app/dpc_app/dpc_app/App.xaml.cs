using Main;
using Matches;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Roster;

namespace dpc_app
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer) : base(platformInitializer)
        {

        }

        //Handles the first page to be shown after the splash screen
        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(Common.Modules.Main.Pages.MainTabbedPageView);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule<MainModule>();
            moduleCatalog.AddModule<MatchesModule>();
            moduleCatalog.AddModule<RosterModule>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
