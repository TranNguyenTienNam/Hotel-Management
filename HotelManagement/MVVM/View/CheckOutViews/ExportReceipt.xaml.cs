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

namespace HotelManagement.MVVM.View.CheckOutViews
{
    /// <summary>
    /// Interaction logic for ExportReceipt.xaml
    /// </summary>
    public partial class ExportReceipt : Window
    {
        public ExportReceipt()
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
                    printDialog.PrintVisual(receipt, "Receipt");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
}
