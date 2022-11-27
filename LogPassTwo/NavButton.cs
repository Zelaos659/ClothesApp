using System;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows;

namespace LogPassTwo
{
    public class NavButton : ListBoxItem
    {
        static NavButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavButton), new FrameworkPropertyMetadata(typeof(NavButton)));
        }

        public string NavText
        {
            get { return (string)GetValue(NavTextProperty); }
            set { SetValue(NavTextProperty, value); }
        }
        public static readonly DependencyProperty NavTextProperty = DependencyProperty.Register("MyProperty", typeof(string), typeof(NavButton), new PropertyMetadata(null));

        public Uri NavUri
        {
            get { return (Uri)GetValue(NavUriProperty); }
            set { SetValue(NavUriProperty, value); }
        }
        public static readonly DependencyProperty NavUriProperty = DependencyProperty.Register("NavUri", typeof(Uri), typeof(NavButton), new PropertyMetadata(null));

        public Geometry Icon
        {
            get { return (Geometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(Geometry), typeof(NavButton), new PropertyMetadata(null));
    }
}
