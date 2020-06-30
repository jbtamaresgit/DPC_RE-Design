using Fantasy.ViewModels;
using Fantasy.ViewModels.Tabs;
using Fantasy.Views;
using Fantasy.Views.Tabs;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;

namespace Fantasy
{
    public class FantasyModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainFantasyView, MainFantasyViewModel>();
            ViewModelLocationProvider.Register<FantasyRankingView, FantasyRankingViewModel>();
            ViewModelLocationProvider.Register<FantasyRosterView, FantasyRosterViewModel>();
            ViewModelLocationProvider.Register<FantasyScoresView, FantasyScoresViewModel>();
        }
    }
}
