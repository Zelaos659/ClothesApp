using LogPass;
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

namespace LogPassTwo.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        ApplicationContext bd = new ApplicationContext();
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public AuthPage()
        {
            InitializeComponent();
        }

        private void LoginBtn(object sender, RoutedEventArgs e)
        {
            if (asd())
            {
                var j = WorkWithBD.Login(loginBox.Text, passBox.Password);
                if (j != null)
                {
                    MainWindow.user = j;
                    if (MainWindow.user.Access == "Admin")
                    {
                        mainWindow.AllOrdNav.Visibility = Visibility.Visible;
                        mainWindow.AddNav.Visibility = Visibility.Visible;
                    }
                    mainWindow.ProfileNav.NavUri = new Uri("Pages/ProfilePage.xaml", UriKind.Relative);
                    mainWindow.sidebar.SelectedItem = null;
                    mainWindow.sidebar.SelectedItem = mainWindow.ProfileNav;
                }
                else
                {
                    CustomMSGbox.Show("Неверно введён логин или пароль!", CustomMSGbox.MsgTitle.Ошибка, CustomMSGbox.MsgButtons.Ок, CustomMSGbox.MsgButtons.Отмена);
                }
            }
        }

        private void RegBtn(object sender, RoutedEventArgs e)
        {
            if (asd() && bd.Users.FirstOrDefault(p => p.Login == loginBox.Text) == null)
            {
                var user = new User()
                {
                    Login = loginBox.Text,
                    Password = passBox.Password,
                    Access = "Customer"
                };
                MainWindow.user = user;
                mainWindow.navframe.Navigate(new Uri("Pages/SecondAuthPage.xaml", UriKind.Relative));
            }
        }

        bool asd()
        {
            if (loginBox.Text.Length < 6 || passBox.Password.Length < 6)
            {
                CustomMSGbox.Show("Поля не могут быть пустыми или содержать меньше 6 символов", CustomMSGbox.MsgTitle.Ошибка, CustomMSGbox.MsgButtons.Ок, CustomMSGbox.MsgButtons.Отмена);
                return false;
            }
            return true;
        }

        private void ResetBD(object sender, RoutedEventArgs e)
        {

        }
    }
}
