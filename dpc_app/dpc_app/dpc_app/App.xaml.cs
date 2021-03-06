﻿using dpc_app.Common.Modules.Main;
using dpc_app.Common.Modules.Matches;
using dpc_app.Common.Modules.Predictions;
using DPCStandings;
using Main;
using Matches;
using Players;
using Predictions;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Plugin.Popups;
using Roster;
using Teams;
using Tournaments;

namespace dpc_app
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer) : base(platformInitializer)
        {

        }

        //Handles the first page to be shown after the splash screen
        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(Common.Modules.Main.Pages.MainTabbedPageView);
            //NavigationService.NavigateAsync(PredictionPages.MainPredictions);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterPopupNavigationService();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule<MainModule>();
            moduleCatalog.AddModule<MatchesModule>();
            moduleCatalog.AddModule<RosterModule>();
            moduleCatalog.AddModule<TournamentUpdatesModule>();
            moduleCatalog.AddModule<DPCStandingsModule>();
            moduleCatalog.AddModule<PlayersModule>();
            moduleCatalog.AddModule<TeamsModule>();
            moduleCatalog.AddModule<PredictionsModule>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
