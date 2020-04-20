using Prism.Ioc;
using Prism.Modularity;
using Teams.ViewModels;
using Teams.Views;

namespace Teams
{
    public class TeamsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<TeamsView, TeamsViewModel>();
        }
    }
}
