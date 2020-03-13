using Main.ViewModels;
using Main.Views;
using Main.Views.TabPages;
using Prism.Ioc;
using Prism.Modularity;

namespace Main
{
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
           
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainTabbedPageView>();
            containerRegistry.RegisterForNavigation<HomeView, HomeViewModel>();
            containerRegistry.RegisterForNavigation<TournamentsView, TournamentsViewModel>();
            containerRegistry.RegisterForNavigation<FantasyView, FantasyViewModel>();
            containerRegistry.RegisterForNavigation<PredictionsView, PredictionsViewModel>();
        }
    }
}
