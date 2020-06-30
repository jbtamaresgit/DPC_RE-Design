using Prism.Mvvm;
using Prism.Navigation;
using System;

namespace Fantasy.ViewModels
{
    public class BaseViewModel : BindableBase, INavigatedAware
    {
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
