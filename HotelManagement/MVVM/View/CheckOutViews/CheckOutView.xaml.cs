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
using System.Windows.Markup;
using HotelManagement.MVVM.View.CheckOutViews;


namespace HotelManagement.MVVM.View
{
    /// <summary>
    /// Interaction logic for CheckOutView.xaml
    /// </summary>
    public partial class CheckOutView : UserControl
    {
        public CheckOutView()
        {
            InitializeComponent();
        }

        private void btnBills_Click(object sender, RoutedEventArgs e)
        {
            (new BillsView()).ShowDialog();
        }

        private void btnEditSurcharge_Click(object sender, RoutedEventArgs e)
        {
            (new SurchargeView()).ShowDialog();
        }
    }
}
