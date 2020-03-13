using Matches.ViewModels;
using Matches.ViewModels.TabViewModels;
using Matches.Views;
using Matches.Views.TabViews;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;

namespace Matches
{
    public class MatchesModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainMatchesView, MainMatchesViewModel>();
            ViewModelLocationProvider.Register<LiveMatchesView, LiveMatchesViewModel>();
            //ViewModelLocationProvider.Register<UpcomingMatchesView, UpcomingMatchesViewModel>();
        }
    }
}
