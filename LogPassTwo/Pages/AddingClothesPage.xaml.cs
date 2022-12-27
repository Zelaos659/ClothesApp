using LogPass;
using LogPassTwo.Data;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
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
        string path;
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
                path = OFDialog.FileName;
                img.Source = new BitmapImage(new Uri(OFDialog.FileName));
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void AddBtn(object sender, RoutedEventArgs e)
        {
            WorkWithBD.SaveProduct(txtTitle.Text, txtDesc.Text, txtPrice.Text, txtCount.Text, path);
            CustomMSGbox.Show("Товар добавлен", CustomMSGbox.MsgTitle.Инфо, CustomMSGbox.MsgButtons.Ок, CustomMSGbox.MsgButtons.Отмена);
        }
    }
}
