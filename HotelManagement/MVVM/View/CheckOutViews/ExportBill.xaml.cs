using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace HotelManagement.MVVM.View.CheckOutViews
{
    /// <summary>
    /// Interaction logic for ExportBill.xaml
    /// </summary>
    public partial class ExportBill : Window
    {
        public ExportBill()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(bill, "Bill");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
}
