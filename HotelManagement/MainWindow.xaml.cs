using System.Windows;
using System.Windows.Input;

namespace HotelManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void btnPopUpExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            (new LoginWindow()).Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BookingWindows bW = new BookingWindows();
            bW.ShowDialog();
        }
    }
}
