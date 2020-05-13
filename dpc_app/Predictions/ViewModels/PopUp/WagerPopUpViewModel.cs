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

        private DelegateCommand _CancelBetCommand;
        public DelegateCommand CancelBetCommand =>
            _CancelBetCommand ?? (_CancelBetCommand = new DelegateCommand(ExecuteCancelBetCommand));

        void ExecuteCancelBetCommand()
        {

        }

        private DelegateCommand _PlaceBetCommand;
        public DelegateCommand PlaceBetCommand =>
            _PlaceBetCommand ?? (_PlaceBetCommand = new DelegateCommand(ExecutePlaceBetCommand));

        void ExecutePlaceBetCommand()
        {
            int testVal = ReturnShards;
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
