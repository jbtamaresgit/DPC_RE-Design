using Matches.ViewModels;
using Matches.ViewModels.TabViewModels;
using Matches.Views;
using Matches.Views.TabViews;
using Prism.Ioc;
using Prism.Modularity;

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
            containerRegistry.RegisterForNavigation<LiveMatchesView, LiveMatchesViewModel>();
        }
    }
}
