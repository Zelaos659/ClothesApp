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
    /// Логика взаимодействия для AddingClothesPage.xaml
    /// </summary>
    public partial class AddingClothesPage : Page
    {
        public AddingClothesPage()
        {
            InitializeComponent();
        }

        private void BrowseBtn(object sender, RoutedEventArgs e)
        {
            var OFDialog = new OpenFileDialog();
            OFDialog.Title = "Выберите фото";
            OFDialog.Filter = "JPG,PNG|*.jpg;*.png";
            OFDialog.Multiselect = false;
            if (OFDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imgASD.Source = new BitmapImage(new Uri(OFDialog.FileName));
            }
        }
    }
}
