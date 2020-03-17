using MvvmHelpers;
using Prism.Commands;
using Prism.Navigation;
using Roster.Models;

namespace Roster.ViewModels
{
    public class RosterUpdatesViewModel : BaseViewModel
    {
        public RosterUpdatesViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public string ImageSrc { get { return "https://vistapointe.net/images/dota-2-3.jpg"; } }

        public string PageTitle { get { return "Roster Updates"; } }

        private ObservableRangeCollection<RosterUpdateModel> _RosterUpdates;
        public ObservableRangeCollection<RosterUpdateModel> RosterUpdates
        {
            get { return _RosterUpdates; }
            set { SetProperty(ref _RosterUpdates, value); }
        }


        private DelegateCommand _NavigateBackCommand;
        public DelegateCommand NavigateBackCommand =>
            _NavigateBackCommand ?? (_NavigateBackCommand = new DelegateCommand(ExecuteNavigateBackCommand));

        void ExecuteNavigateBackCommand()
        {
            base.GoBackAsync();
        }


        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            RosterUpdates = new ObservableRangeCollection<RosterUpdateModel>()
            {
                new RosterUpdateModel
                {
                    PlayerImageSrc = "https://liquipedia.net/commons/images/8/8e/Gpk.png",
                    TeamImageSrc = "https://liquipedia.net/commons/images/thumb/7/72/Gambit_Esports.png/600px-Gambit_Esports.png",
                    Announcement = "gpk~ is now a member of Gambit",
                    DateReleased = "2020/03/09"
                },
                new RosterUpdateModel
                {
                    PlayerImageSrc = "https://liquipedia.net/commons/images/8/8e/Gpk.png",
                    TeamImageSrc = "https://liquipedia.net/commons/images/thumb/7/72/Gambit_Esports.png/600px-Gambit_Esports.png",
                    Announcement = "gpk~ is now a member of Gambit",
                    DateReleased = "2020/03/09"
                },
            };
        }
    }
}
