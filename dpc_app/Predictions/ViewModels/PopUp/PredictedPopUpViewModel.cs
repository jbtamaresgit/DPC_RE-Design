using dpc_app.Common.Extensions;
using dpc_app.Common.Modules.Predictions;
using Predictions.Models;
using Prism.Commands;
using Prism.Navigation;
using System;

namespace Predictions.ViewModels.PopUp
{
    public class PredictedPopUpViewModel : BaseViewModel
    {
        public PredictedPopUpViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        private UpcomingMatchesModel _UpcomingMatchItem;
        public UpcomingMatchesModel UpcomingMatchItem
        {
            get { return _UpcomingMatchItem; }
            set { SetProperty(ref _UpcomingMatchItem, value); }
        }

        private string _MatchDate;
        public string MatchDate
        {
            get { return _MatchDate; }
            set { SetProperty(ref _MatchDate, value); }
        }

        private string _WagerShards;
        public string WagerShards
        {
            get { return _WagerShards; }
            set { SetProperty(ref _WagerShards, value); }
        }

        private string _ReturnShards;
        public string ReturnShards
        {
            get { return _ReturnShards; }
            set { SetProperty(ref _ReturnShards, value); }
        }

        private DelegateCommand _CloseMenuCommand;
        public DelegateCommand CloseMenuCommand =>
            _CloseMenuCommand ?? (_CloseMenuCommand = new DelegateCommand(ExecuteCloseMenuCommand));

        void ExecuteCloseMenuCommand()
        {
            NavigationService.GoBackAsync();
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey(PredictionParameterConsts.PredictionMatchModel))
            {
                UpcomingMatchItem = (UpcomingMatchesModel)parameters[PredictionParameterConsts.PredictionMatchModel];

                if (UpcomingMatchItem != null)
                {
                    MatchDate = $"{UpcomingMatchItem.MatchDate:MMMM} {UpcomingMatchItem.MatchDate.Day}";
                    WagerShards = StringFormatterExtension.PluraliseFormatter("Shard;Shards", Convert.ToInt32(UpcomingMatchItem.WagerShards));
                    ReturnShards = StringFormatterExtension.PluraliseFormatter("Shard;Shards", Convert.ToInt32(UpcomingMatchItem.ReturnShards));
                }
            }
        }
    }
}
