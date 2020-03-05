using System;
using System.Collections.Generic;
using System.Text;

namespace Matches.ViewModels
{
    public class MainMatchesViewModel : BaseViewModel
    {
        public MainMatchesViewModel()
        {
        }

        private int _SelectedViewModelIndex;
        public int SelectedViewModelIndex
        {
            get { return _SelectedViewModelIndex; }
            set { SetProperty(ref _SelectedViewModelIndex, value); }
        }
    }
}
