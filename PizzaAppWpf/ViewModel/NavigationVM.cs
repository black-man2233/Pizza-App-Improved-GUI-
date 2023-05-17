using System;
using System.Windows.Input;
using PizzaAppWpf.Utilities;

namespace PizzaAppWpf.ViewModel
{
    class NavigationVM : Utilities.ViewModelBase
    {
        #region Properties
        private object _currentView = new MenuVM();
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
        #endregion

        #region ICommands
        public ICommand HomeCommand { get; set; }
        public ICommand CartCommand { get; set; }
        public ICommand MenuCommand { get; set; }
        public ICommand CheckOutCommand { get; set; }

        #endregion

        #region CommandsFunction
        private void Home(Object obj) => CurrentView = new HomeVM();
        private void Menu(Object obj) => CurrentView = new MenuVM();
        private void Cart(Object obj) => CurrentView = new CartVM();
        private void CheckOut(Object obj) => CurrentView = new CheckOutVM();

        #endregion

        #region Constructor
        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            MenuCommand = new RelayCommand(Menu);
            CartCommand = new RelayCommand(Cart);
            CheckOutCommand = new RelayCommand(CheckOut);

            //Startup Page
            this.CurrentView = new HomeVM();
        }
        #endregion
    }
}
