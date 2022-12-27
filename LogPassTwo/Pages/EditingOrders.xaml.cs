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

namespace LogPassTwo.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditingOrders.xaml
    /// </summary>
    public partial class EditingOrders : Page
    {
        public EditingOrders()
        {
            InitializeComponent();
        }

        private void TNumEdit(object sender, RoutedEventArgs e)
        {
            txtTest.Text = EditOrderInfo.Show(1);
        }

        private void EditStat(object sender, RoutedEventArgs e)
        {
            txtTest.Text = EditOrderInfo.Show(2);
        }
    }
}
