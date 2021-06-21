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

namespace HotelManagement.MVVM.View
{
    /// <summary>
    /// Interaction logic for BillsView.xaml
    /// </summary>
    public partial class CheckOutView : UserControl
    {


        public CheckOutView()
        {
            InitializeComponent();
        }

        private void btnSearchBills_Click(object sender, RoutedEventArgs e)
        {         
            (new SearchBillsWindow()).Show();      
        }

        private void btnEditSurcharge_Click(object sender, RoutedEventArgs e)
        {
            (new EditSurchargeWindow()).Show();
        }
    }
}
