using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LogPassTwo
{
    public class ProductItem : ListBoxItem
    { 
        static ProductItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ProductItem), new FrameworkPropertyMetadata(typeof(ProductItem)));
        }



        public string ProductDesc
        {
            get { return (string)GetValue(ProductDescProperty); }
            set { SetValue(ProductDescProperty, value); }
        }
        public static readonly DependencyProperty ProductDescProperty = DependencyProperty.Register("ProductDesc", typeof(string), typeof(ProductItem), new PropertyMetadata(null));



        public string ProductName
        {
            get { return (string)GetValue(ProductNameProperty); }
            set { SetValue(ProductNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProductName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductNameProperty =
            DependencyProperty.Register("ProductName", typeof(string), typeof(ProductItem), new PropertyMetadata(null));



        public string ProductPrice
        {
            get { return (string)GetValue(ProductPriceProperty); }
            set { SetValue(ProductPriceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProductPrice.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductPriceProperty =
            DependencyProperty.Register("ProductPrice", typeof(string), typeof(ProductItem), new PropertyMetadata(null));



        public ImageSource ProductImage
        {
            get { return (ImageSource)GetValue(ProductImageProperty); }
            set { SetValue(ProductImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductImageProperty =
            DependencyProperty.Register("ProductImage", typeof(ImageSource), typeof(ProductItem), new PropertyMetadata(null));



    }
}
