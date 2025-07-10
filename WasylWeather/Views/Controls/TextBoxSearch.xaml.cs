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
        
        public TextBoxSearch()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Textbox.Clear();
            Textbox.Focus();
        }

        private void Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(Textbox.Text))
            {
                EnterTXT.Visibility = Visibility.Visible;
            }
            else
            {
                EnterTXT.Visibility = Visibility.Collapsed;
            }
        }
    }
}
