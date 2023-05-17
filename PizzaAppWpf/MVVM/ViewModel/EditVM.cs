using System.Windows.Input;
using PizzaAppWpf.Model;
using PizzaAppWpf.MVVM.Model;
using PizzaAppWpf.Utilities;
#pragma warning disable
namespace PizzaAppWpf.MVVM.ViewModel
{
    class EditVM : Utilities.ViewModelBase
    {
        private OrderModel _selectedOrder;

        public OrderModel SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }


        public ICommand ToppingsCheckedCommand   { get; set; }
        public ICommand ToppingsUnCheckedCommand { get; set; }


        void ToppingChecked(object sender)
        {
        }

        void ToppingUnChecked(object sender)
        {
        }

        public EditVM(OrderModel o)
        {
            this.SelectedOrder = o;

            ToppingsCheckedCommand = new RelayCommand(ToppingChecked);
            ToppingsUnCheckedCommand = new RelayCommand(ToppingUnChecked);
        }
    }
}