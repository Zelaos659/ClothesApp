using LogPass.Data;
using LogPassTwo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        ApplicationContext bd = new ApplicationContext();
        public EditingOrders()
        {
            InitializeComponent();
            dgOrd.ItemsSource = bd.Orders.Include(p => p.User).ToList();
        }

        private void TNumEdit(object sender, RoutedEventArgs e)
        {
            if (dgOrd.SelectedItem != null)
            {
                var ord = bd.Orders.FirstOrDefault(p => p.OrderId == (dgOrd.SelectedItem as Order).OrderId);
                ord.TrackNumber = EditOrderInfo.Show(1);
                bd.SaveChanges();
                searchTxt.Text = "";
                dgOrd.ItemsSource = bd.Orders.Include(p => p.User).ToList();
            }
            else
                CustomMSGbox.Show("Для изменения выберите заказ!", CustomMSGbox.MsgTitle.Ошибка, CustomMSGbox.MsgButtons.Ок, CustomMSGbox.MsgButtons.Нет);
        }

        private void EditStat(object sender, RoutedEventArgs e)
        {
            if (dgOrd.SelectedItem != null)
            {
                var ord = bd.Orders.FirstOrDefault(p => p.OrderId == (dgOrd.SelectedItem as Order).OrderId);
                ord.Status = EditOrderInfo.Show(2);
                bd.SaveChanges();
                searchTxt.Text = "";
                dgOrd.ItemsSource = bd.Orders.Include(p => p.User).ToList();
            }
            else
                CustomMSGbox.Show("Для изменения выберите заказ!", CustomMSGbox.MsgTitle.Ошибка, CustomMSGbox.MsgButtons.Ок, CustomMSGbox.MsgButtons.Нет);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (searchTxt.Text != "")
                dgOrd.ItemsSource = bd.Orders.Where(p=>p.OrderId == Convert.ToInt32(searchTxt.Text)).Include(p => p.User).ToList();
            else
                dgOrd.ItemsSource = bd.Orders.Include(p => p.User).ToList();
        }
    }
}
