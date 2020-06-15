using dpc_app.Common.Modules.Predictions;
using Predictions.Models;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace Predictions.ViewModels.PopUp
{
    public class WagerPopUpViewModel : BaseViewModel
    {
        public WagerPopUpViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        private Color UnselectedColor = Color.FromHex("#585858");
        private Color SelectedColor = Color.FromHex("#0099FF");

        private string PredictedTeam { get; set; }

        private Color _TeamAColor;
        public Color TeamAColor
        {
            get { return _TeamAColor; }
            set { SetProperty(ref _TeamAColor, value); }
        }

        private Color _TeamBColor;
        public Color TeamBColor
        {
            get { return _TeamBColor; }
            set { SetProperty(ref _TeamBColor, value); }
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

        private DelegateCommand<string> _SelectedTeamCommand;
        public DelegateCommand<string> SelectedTeamCommand =>
            _SelectedTeamCommand ?? (_SelectedTeamCommand = new DelegateCommand<string>(ExecuteSelectedTeamCommand));

        void ExecuteSelectedTeamCommand(string SelectedTeamName)
        {
            HandleSelectedTeam(SelectedTeamName);
        }

        void HandleSelectedTeam(string SelectedTeamName)
        {
            PredictedTeam = SelectedTeamName;

            if (SelectedTeamName.Equals(UpcomingMatchItem.TeamA_Name))
            {
                TeamAColor = SelectedColor;
                TeamBColor = UnselectedColor;
            }
            else
            {
                TeamBColor = SelectedColor;
                TeamAColor = UnselectedColor;
            }  
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
            UpcomingMatchItem.IsPredicted = true;
            UpcomingMatchItem.PredictedTeam = PredictedTeam;

            NavigationParameters NavigationParameters = new NavigationParameters
            {
                { PredictionParameterConsts.PredictionMatchModel , UpcomingMatchItem }
            };

            NavigationService.GoBackAsync(NavigationParameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            TeamAColor = SelectedColor;
            TeamBColor = UnselectedColor;

            if (parameters.ContainsKey(PredictionParameterConsts.PredictionMatchModel))
            {
                UpcomingMatchItem = (UpcomingMatchesModel)parameters[PredictionParameterConsts.PredictionMatchModel];

                if(UpcomingMatchItem != null)
                {
                    MatchDate = $"{UpcomingMatchItem.MatchDate.ToString("MMMM")} {UpcomingMatchItem.MatchDate.Day}";
                    PredictedTeam = UpcomingMatchItem.TeamA_Name;
                }
            }
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }


    }
}
