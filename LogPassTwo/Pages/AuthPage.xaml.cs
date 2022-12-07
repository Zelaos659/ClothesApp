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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public AuthPage()
        {
            InitializeComponent();
        }

        private void LoginBtn(object sender, RoutedEventArgs e)
        {
            MainWindow.user = WorkWithBD.Login(loginBox.Text,passBox.Password);
            if (MainWindow.user.Access == "Admin") 
                mainWindow.AddNav.Visibility = Visibility.Visible;

            mainWindow.ProfileNav.NavUri = new Uri("Pages/ProfilePage.xaml", UriKind.Relative);
            mainWindow.sidebar.SelectedItem = null;
            mainWindow.sidebar.SelectedItem = mainWindow.ProfileNav;

            // напохуй сделать тут же изменение навЛинков при авторизированном пользователе. 
        }

        private void RegBtn(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Итог: {WorkWithBD.Register(loginBox.Text, passBox.Password)}");
        }

        private void ResetBD(object sender, RoutedEventArgs e)
        {

        }
    }
}
