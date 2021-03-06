﻿using DPCStandings.ViewModels;
using DPCStandings.Views;
using Prism.Ioc;
using Prism.Modularity;
using System;

namespace DPCStandings
{
    public class DPCStandingsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
           
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<DPCStandingsOverview, DPCStandingsOverviewViewModel>();
        }
    }
}
