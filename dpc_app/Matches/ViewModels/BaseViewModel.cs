using Prism.Mvvm;
using Prism.Navigation;

namespace Matches.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware
    {

        public BaseViewModel()
        {

        }

        private bool _IsBusy = false;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set { SetProperty(ref _IsBusy, value); }
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }
    }
}
