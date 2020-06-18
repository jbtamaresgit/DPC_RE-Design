using dpc_app.Common.Extensions;
using MvvmHelpers;
using Predictions.Models;
using Prism.Commands;
using Prism.Navigation;

namespace Predictions.ViewModels.Tabs
{
    public class OnGoingViewModel : BaseViewModel, IInitialize
    {
        public OnGoingViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        private ObservableRangeCollection<OnGoingMatchesModel> _OnGoingMatches;
        public ObservableRangeCollection<OnGoingMatchesModel> OnGoingMatches
        {
            get { return _OnGoingMatches; }
            set { SetProperty(ref _OnGoingMatches, value); }
        }

        private DelegateCommand<OnGoingMatchesModel> _SelectCommand;
        public DelegateCommand<OnGoingMatchesModel> SelectCommand =>
            _SelectCommand ?? (_SelectCommand = new DelegateCommand<OnGoingMatchesModel>(ExecuteSelectCommand));

        void ExecuteSelectCommand(OnGoingMatchesModel SelectedItem)
        {

        }

        public void Initialize(INavigationParameters parameters)
        {
            InitializeCollection();
        }

        private void InitializeCollection()
        {
            OnGoingMatches = new ObservableRangeCollection<OnGoingMatchesModel>
            {
                new OnGoingMatchesModel
                {
                    TeamA_ImgSource = "https://liquipedia.net/commons/images/thumb/8/89/FlyToMoon_Logo.png/600px-FlyToMoon_Logo.png",
                    TeamA_TeamName = "FlyToMoon",
                    TeamB_ImgSource = "https://upload.wikimedia.org/wikipedia/en/thumb/a/ac/NaVi_logo.svg/1200px-NaVi_logo.svg.png",
                    TeamB_TeamName = "Natus Vincere",
                    GameRound = "Game 1",
                    GameRoundScore = "15 : 31",
                    GameTime =  "32:46",
                    PredictedTeam = "FlyToMoon",
                    ReturnShards = StringFormatterExtension.PluraliseFormatter("Shard;Shards", 200),
                    WagerShards = StringFormatterExtension.PluraliseFormatter("Shard;Shards", 100)
                }
            };
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }
    }
}
