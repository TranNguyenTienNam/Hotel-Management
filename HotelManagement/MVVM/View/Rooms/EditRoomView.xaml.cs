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

namespace HotelManagement.MVVM.View
{
    public partial class EditRoomView : Window
    {
        public EditRoomView(int MaPhong, string TenPhong, string LoaiPhong, decimal DonGia, int SoNgToiDa, string GhiChu)
        {
            InitializeComponent();
            tbRoomId.Text = MaPhong.ToString();
            tbRoomName.Text = TenPhong;
            cbbRoomType.SelectedItem = LoaiPhong;
            tbPrice.Text = DonGia.ToString();
            tbMax.Text = SoNgToiDa.ToString();
            tbNote.Text = GhiChu;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
