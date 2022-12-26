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
        #region ICommands
        public ICommand HomeCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand ProductCommand { get; set; }
        #endregion

        #region CommandsFunction
        private void Home(Object obj) => CurrentView = new HomeVM();
        private void Customer(Object obj) => CurrentView = new CustomersVM();
        private void Product(Object obj) => CurrentView = new ProductsVM();
        #endregion
        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            CustomerCommand = new RelayCommand(Customer);
            ProductCommand = new RelayCommand(Product);

            //Startup Page
            this.CurrentView = new HomeVM();
        }

    }
}
