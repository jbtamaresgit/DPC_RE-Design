using Prism.Ioc;
using Prism.Modularity;
using Tournaments.ViewModels;
using Tournaments.Views;

namespace Tournaments
{
    public class TournamentUpdatesModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<TournamentUpdatesView, TournamentUpdatesViewModel>();
        }
    }
}
