using LogPass.Data;
using LogPassTwo.Data;
using Microsoft.VisualBasic;
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
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Page
    {
        ApplicationContext bd = new ApplicationContext();
        Product prod;
        public Catalog()
        {
            InitializeComponent();
            ListProducts.ItemsSource = bd.Products.ToList();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            prod = bd.Products.FirstOrDefault(p => p.ProductId == ((int)((Button)sender).Tag));
            Valid();
        }

        private void Valid()
        {
            if (MainWindow.user == null)
            {
                CustomMSGbox.Show("Авторизируйтесь для заказа!", CustomMSGbox.MsgTitle.Ошибка, CustomMSGbox.MsgButtons.Ок, CustomMSGbox.MsgButtons.Нет);
                return;
            }
            if (MainWindow.user.Access == "Админ")
            {
                CustomMSGbox.Show("Тест", CustomMSGbox.MsgTitle.Инфо, CustomMSGbox.MsgButtons.Ок, CustomMSGbox.MsgButtons.Нет);
                return;
            }
            if (prod.Count == 0)
            {
                CustomMSGbox.Show("Товара не осталось на складе.",CustomMSGbox.MsgTitle.Ошибка,CustomMSGbox.MsgButtons.Ок, CustomMSGbox.MsgButtons.Нет);
                return;
            }
            CustomMSGbox.Show("Товар заказан", CustomMSGbox.MsgTitle.Инфо, CustomMSGbox.MsgButtons.Ок, CustomMSGbox.MsgButtons.Нет);
            prod.Count--;
            bd.SaveChanges();
            ListProducts.ItemsSource = bd.Products.ToList();
        }
    }
}
