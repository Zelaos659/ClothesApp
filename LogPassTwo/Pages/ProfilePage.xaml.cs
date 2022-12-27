﻿using System;
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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        MainWindow mainWindow = (MainWindow) System.Windows.Application.Current.MainWindow;
        public ProfilePage()
        {
            InitializeComponent();
            fiTxt.Text = $"Фамилия имя: {MainWindow.user.SecondName} {MainWindow.user.FirstName}";
            numberTxt.Text = $"Номер телефона: {MainWindow.user.PhoneNumber}";
            addressTxt.Text = $"Адрес: {MainWindow.user.Address}";
        }

        private void logoutBtn(object sender, RoutedEventArgs e)
        {
            //txts.Text = MainWindow.user.Login;
            DialogResult result = CustomMSGbox.Show("Вы точно хотите выйти?", CustomMSGbox.MsgTitle.Внимание, CustomMSGbox.MsgButtons.Да, CustomMSGbox.MsgButtons.Нет);
            if (result == DialogResult.Yes)
            {
                MainWindow.user = null;
                mainWindow.AddNav.Visibility = Visibility.Hidden;
                mainWindow.AllOrdNav.Visibility = Visibility.Hidden;
                mainWindow.ProfileNav.NavUri = new Uri("Pages/AuthPage.xaml", UriKind.Relative);
                mainWindow.sidebar.SelectedItem = null;
                mainWindow.sidebar.SelectedItem = mainWindow.ProfileNav;
            }
        }
    }
}
