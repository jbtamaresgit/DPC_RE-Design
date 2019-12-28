using Main.Views;
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
        }
    }
}
