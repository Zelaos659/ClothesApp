﻿using LogPass.Data;
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
        ApplicationContext bd = new ApplicationContext();
        public MyOrders()
        {
            InitializeComponent();
            ListProducts.ItemsSource = bd.Orders.Where(p=>p.UserId == MainWindow.user.UserId).Include(p=>p.Product).ToList();
        }
    }
}
