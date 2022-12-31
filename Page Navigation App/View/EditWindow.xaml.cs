using Page_Navigation_App.Model;
using Page_Navigation_App.ViewModel;
using System.Windows;

namespace Page_Navigation_App.View
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
