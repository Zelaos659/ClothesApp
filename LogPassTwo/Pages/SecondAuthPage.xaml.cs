using LogPass;
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
    /// Логика взаимодействия для SecondAuthPage.xaml
    /// </summary>
    public partial class SecondAuthPage : Page
    {
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public SecondAuthPage()
        {
            InitializeComponent();
        }

        private void CreateAcc(object sender, RoutedEventArgs e)
        {
            if (firstNameTxt.Text.Length < 1 || secondNameTxt.Text.Length < 1 || phoneTxt.Text.Length < 1 || addressTxt.Text.Length < 1)
            {
                CustomMSGbox.Show("Поля не могут быть пустыми!",CustomMSGbox.MsgTitle.Ошибка,CustomMSGbox.MsgButtons.Ок,CustomMSGbox.MsgButtons.Отмена);
            }
            else
            {
                MainWindow.user.FirstName = firstNameTxt.Text;
                MainWindow.user.SecondName = secondNameTxt.Text;
                MainWindow.user.PhoneNumber = phoneTxt.Text;
                MainWindow.user.Address = addressTxt.Text;
                WorkWithBD.Register(MainWindow.user);
                CustomMSGbox.Show("Вы успешно зарегистрировались!", CustomMSGbox.MsgTitle.Инфо, CustomMSGbox.MsgButtons.Ок, CustomMSGbox.MsgButtons.Отмена);
                mainWindow.ProfileNav.NavUri = new Uri("Pages/ProfilePage.xaml", UriKind.Relative);
                mainWindow.sidebar.SelectedItem = null;
                mainWindow.sidebar.SelectedItem = mainWindow.ProfileNav;
            }
        }
    }
}
