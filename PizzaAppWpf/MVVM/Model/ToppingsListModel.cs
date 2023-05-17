using System.Collections.ObjectModel;
using PizzaAppWpf.Model;
#pragma warning disable
namespace PizzaAppWpf.MVVM.Model
{
    public class ToppingsListModel
    {
        public ObservableCollection<ToppingsModel> Toppings { get; set; }
    }
}
