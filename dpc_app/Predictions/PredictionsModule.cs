using Predictions.ViewModels;
using Predictions.ViewModels.Tabs;
using Predictions.Views;
using Predictions.Views.PopUp;
using Predictions.Views.Tabs;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using System;

namespace Predictions
{
    public class PredictionsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPredictions, MainPredictionsViewModel>();
            ViewModelLocationProvider.Register<UpcomingView, UpcomingViewModel>();
            ViewModelLocationProvider.Register<ResultsView, ResultsViewModel>();
            ViewModelLocationProvider.Register<OnGoingView, OnGoingViewModel>();
            containerRegistry.RegisterForNavigation<WagerPopUpView>();
        }
    }
}
