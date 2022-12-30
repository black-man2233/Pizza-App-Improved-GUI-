using Page_Navigation_App.Utilities;
using System;
using System.Windows.Input;

namespace Page_Navigation_App.ViewModel
{
    class NavigationVM : Utilities.ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        private static string _totalCartItems = "0";
        public string TotalCartItems
        {
            get
            {
                return _totalCartItems;
            }
            set
            {
                _totalCartItems = value;
                OnPropertyChanged("TotalCartItems");
            }
        }

        public static void ItemsCountUpdater()
        {
            int itemsInCart = HomeVM._cart.Count;
            _totalCartItems = $"{itemsInCart}";
        }

        #region ICommands
        public ICommand HomeCommand { get; set; }
        public ICommand CartCommand { get; set; }
        #endregion

        #region CommandsFunction
        private void Home(Object obj) => CurrentView = new HomeVM();
        private void Product(Object obj) => CurrentView = new CartVM();
        #endregion
        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            CartCommand = new RelayCommand(Product);

            //Startup Page
            this.CurrentView = new HomeVM();
        }

    }
}
