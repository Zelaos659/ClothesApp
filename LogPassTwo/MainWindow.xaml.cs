using LogPass.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LogPassTwo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static User user = null;
        static ApplicationContext bd = new ApplicationContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ResizeWindow(object sender, RoutedEventArgs e)
        {
            
        }

        private void HideWindow(object sender, RoutedEventArgs e)
        {

        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selected = sidebar.SelectedItem as NavButton;

            if (sidebar.SelectedItem == OrdersNav && user == null)
            {
                CustomMSGbox.Show("Для просмотра заказов необходимо авторизироваться!",CustomMSGbox.MsgTitle.Инфо,CustomMSGbox.MsgButtons.Ок,CustomMSGbox.MsgButtons.Нет);
                sidebar.SelectedItem = ProfileNav;
            }

            else if (sidebar.SelectedItem != null)
            {
                navframe.Navigate(selected.NavUri);
                TitleIcon.Data = selected.Icon;
                TitleName.Text = $"Clothes | {selected.NavText}";
            }
            
        }

        private void GridDrag(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
