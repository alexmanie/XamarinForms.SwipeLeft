using System;
using Prism.Navigation;
using Prism.Commands;
using System.Diagnostics;

namespace SwipeLeft.ViewModels
{
    public class MainPageViewModel : ViewModelBase, INavigationAware
    {
        protected INavigationService NavigationService { get; private set; }

        public DelegateCommand NavigateCommand => new DelegateCommand(NavigateCommandMethod);

        public MainPageViewModel(INavigationService navigationService)
        {
            this.NavigationService = navigationService;

            base.Title = "Main Page";
        }

        #region [ Commands ]

        void NavigateCommandMethod()
        {
            try
            {
                this.NavigationService.NavigateAsync("DetailPage", null, null, true);
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(ex.Message);
#endif
            }
        }

        #endregion

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }
    }
}
