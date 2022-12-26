using Page_Navigation_App.Model;
using PizzaApp_WPF.Model;
using System.Collections.ObjectModel;

namespace Page_Navigation_App.ViewModel
{
    class HomeVM : Utilities.ViewModelBase
    {
        static DataBaseModel db = new();
        #region Properties
        private ObservableCollection<PizzaModel>? _pizzaList = new(db.PizzaList);
        public ObservableCollection<PizzaModel> PizzaList
        {
            get => _pizzaList;
            set
            {
                _pizzaList = value;
                OnPropertyChanged("MyProperty");
            }
        }

        private ObservableCollection<OrderModel> _cart = new();
        public ObservableCollection<OrderModel> Cart
        {
            get
            {
                return _cart;
            }
            set
            {
                _cart = value;
                OnPropertyChanged("Cart");
            }
        }

        private ObservableCollection<SidesModel> _sides = new();
        public ObservableCollection<SidesModel> Sides
        {
            get
            {
                return _sides;
            }
            set
            {
                _sides = value;
                OnPropertyChanged("Sides");
            }
        }
        #endregion






    }
}
