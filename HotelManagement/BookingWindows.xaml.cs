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
using System.Windows.Shapes;
using HotelManagement.MVVM.ViewModel;
using System.Text.RegularExpressions;

namespace HotelManagement
{
    /// <summary>
    /// Interaction logic for BookingWindows.xaml
    /// </summary>
    public partial class BookingWindows : Window
    {
        public BookingWindows()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbPhone_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
