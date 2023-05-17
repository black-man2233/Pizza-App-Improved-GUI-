using System.Windows;
using PizzaAppWpf.Model;
using PizzaAppWpf.ViewModel;

namespace PizzaAppWpf.View
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    partial class EditWindow : Window
    {
        public EditWindow(OrderModel o)
        {
            InitializeComponent();
            EditVM vm = new(o);
            this.DataContext = vm;
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
