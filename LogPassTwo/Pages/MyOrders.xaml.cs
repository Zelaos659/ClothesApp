using LogPass.Data;
using LogPassTwo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LogPassTwo.Pages
{
    /// <summary>
    /// Логика взаимодействия для MyOrders.xaml
    /// </summary>
    public partial class MyOrders : Page
    {
        LogPass.Data.ApplicationContext bd = new LogPass.Data.ApplicationContext();
        Order ord;
        int x = 0;
        public MyOrders()
        {
            InitializeComponent();
            ListProducts.ItemsSource = bd.Orders.Where(p=>p.UserId == MainWindow.user.UserId && p.Status != "Получено").Include(p=>p.Product).ToList();
        }

        private void DelOrd(object sender, RoutedEventArgs e)
        {
            ord = bd.Orders.FirstOrDefault(p => p.OrderId == (int)((System.Windows.Controls.Button)sender).Tag);
            DialogResult result = CustomMSGbox.Show("Вы точно хотите удалить заказ?", CustomMSGbox.MsgTitle.Внимание, CustomMSGbox.MsgButtons.Да, CustomMSGbox.MsgButtons.Нет);
            if (result == DialogResult.Yes)
            {
                bd.Orders.Remove(ord);
                bd.SaveChanges();
            }
            ListP();
        }

        private void ClaimOrd(object sender, RoutedEventArgs e)
        {
            ord = bd.Orders.FirstOrDefault(p => p.OrderId == (int)((System.Windows.Controls.Button)sender).Tag);

            if (ord.Status == "Получите на почте")
                ord.Status = "Получено";

            else if (ord.Status == "Получено")
                CustomMSGbox.Show("Товар уже получен!", CustomMSGbox.MsgTitle.Ошибка, CustomMSGbox.MsgButtons.Ок, CustomMSGbox.MsgButtons.Нет);

            else
                CustomMSGbox.Show("Товар ещё не пришёл на почту", CustomMSGbox.MsgTitle.Ошибка, CustomMSGbox.MsgButtons.Ок, CustomMSGbox.MsgButtons.Нет);

            bd.SaveChanges();
            ListP();
        }

        private void xBtn_Click(object sender, RoutedEventArgs e)
        {
            if (x == 0)
            {
                x = 1;
                xBtn.Content = "Скрыть полученные товары";
                ListP();
            }
            else if (x == 1)
            {
                x = 0;
                xBtn.Content = "Показать полученные товары";
                ListP();
            }
        }
        private void ListP()
        {
            if (x == 1)
            {
                ListProducts.ItemsSource = bd.Orders.Where(p => p.UserId == MainWindow.user.UserId).Include(p => p.Product).ToList();
            }
            else if (x == 0)
            {
                ListProducts.ItemsSource = bd.Orders.Where(p => p.UserId == MainWindow.user.UserId && p.Status != "Получено").Include(p => p.Product).ToList();
            }
        }
    }
}
