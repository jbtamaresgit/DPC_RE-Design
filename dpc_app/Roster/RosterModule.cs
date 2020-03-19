using Prism.Ioc;
using Prism.Modularity;
using Roster.ViewModels;
using Roster.Views;

namespace Roster
{
    public class RosterModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<RosterUpdatesView, RosterUpdatesViewModel>();
        }
    }
}
