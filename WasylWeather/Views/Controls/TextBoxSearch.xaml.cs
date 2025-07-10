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

namespace WasylWeather.Views.Controls
{
    /// <summary>
    /// Логика взаимодействия для TextBoxSearch.xaml
    /// </summary>
    public partial class TextBoxSearch : UserControl
    {
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public TextBoxSearch()
        {
            InitializeComponent();

        }
        

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(TextBoxSearch), new PropertyMetadata(string.Empty));
    }
}
