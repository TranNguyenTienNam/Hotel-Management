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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using HotelManagement.MVVM.Model;
using HotelManagement.Object.minh_objects;
using System.Collections.ObjectModel;

namespace HotelManagement.MVVM.View
{
    /// <summary>
    /// Interaction logic for SearchBillsWindow.xaml
    /// </summary>
    public partial class SearchBillsWindow : Window
    {
        public SearchBillsWindow()
        {
            InitializeComponent();
        }



        private void Window_Activated(object sender, EventArgs e)
        {

        }
    }
}
