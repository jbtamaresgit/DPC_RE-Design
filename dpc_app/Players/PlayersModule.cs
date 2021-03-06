﻿using Players.ViewModels;
using Players.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace Players
{
    public class PlayersModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<PlayerListView, PlayerListViewModel>();
        }
    }
}
