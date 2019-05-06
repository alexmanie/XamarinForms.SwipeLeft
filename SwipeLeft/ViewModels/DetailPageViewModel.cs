using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Prism.Navigation;
using SwipeLeft.Common;

namespace SwipeLeft.ViewModels
{
    public class DetailPageViewModel : ViewModelBase, INavigationAware
    {
        protected INavigationService NavigationService { get; private set; }

        public DetailPageViewModel(INavigationService navigationService)
        {
            this.NavigationService = navigationService;

            CreateItems();

            ActionsHandler.DeleteItem += RemoveItem;
        }

        #region [ Bindings ]

        private ObservableCollection<MyItem> _items;
        public ObservableCollection<MyItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        #endregion

        #region [ Private methods ]

        private void RemoveItem(string email)
        {
            try
            {
                var item = this.Items.Where(i => i.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                if (item != null)
                    this.Items.Remove(item);
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(ex.Message);
#endif
            }
        }

        #endregion



        private void CreateItems()
        {
            this.Items = new ObservableCollection<MyItem>();

            this.Items.Add(new MyItem { Name = "Alex Mañé", Email = "alex.martinez@raona.com", BirthDate = new DateTime(1982, 1, 29) });
            this.Items.Add(new MyItem { Name = "Josefa Papagallos Fuentsanta", Email = "a@a.com", BirthDate = DateTime.Today.AddYears(-30) });
            this.Items.Add(new MyItem { Name = string.Empty, Email = "fakeemail@corp.com", BirthDate = DateTime.UtcNow });
        }


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
