using dpc_app.Common.Modules.Predictions;
using Predictions.Models;
using Prism.Commands;
using Prism.Navigation;

namespace Predictions.ViewModels.PopUp
{
    public class WagerPopUpViewModel : BaseViewModel
    {
        public WagerPopUpViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        private int _ReturnShards;
        public int ReturnShards
        {
            get { return _ReturnShards; }
            set { SetProperty(ref _ReturnShards, value); }
        }

        private int _WagerShards;
        public int WagerShards
        {
            get { return _WagerShards; }
            set { SetProperty(ref _WagerShards, value); }
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

        private DelegateCommand _CancelBetCommand;
        public DelegateCommand CancelBetCommand =>
            _CancelBetCommand ?? (_CancelBetCommand = new DelegateCommand(ExecuteCancelBetCommand));

        void ExecuteCancelBetCommand()
        {
            NavigationService.GoBackAsync();
        }

        private DelegateCommand _PlaceBetCommand;
        public DelegateCommand PlaceBetCommand =>
            _PlaceBetCommand ?? (_PlaceBetCommand = new DelegateCommand(ExecutePlaceBetCommand));

        void ExecutePlaceBetCommand()
        {
            UpcomingMatchItem.IsPredicted = true;
            UpcomingMatchItem.WagerShards = $"{WagerShards}";
            UpcomingMatchItem.ReturnShards = $"{WagerShards * 2}";

            NavigationParameters NavigationParameters = new NavigationParameters
            {
                { PredictionParameterConsts.PredictionMatchModel , UpcomingMatchItem }
            };

            NavigationService.GoBackAsync(NavigationParameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey(PredictionParameterConsts.PredictionMatchModel))
            {
                UpcomingMatchItem = (UpcomingMatchesModel)parameters[PredictionParameterConsts.PredictionMatchModel];

                if(UpcomingMatchItem != null)
                {
                    MatchDate = $"{UpcomingMatchItem.MatchDate.ToString("MMMM")} {UpcomingMatchItem.MatchDate.Day}";
                }
            }
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }


    }
}
