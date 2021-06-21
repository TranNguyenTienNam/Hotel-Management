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
using HotelManagement.Object.minh_objects;
using System.Data.SqlClient;
using System.Configuration;

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
        private decimal get_surcharge(decimal subtotal)
        {
            decimal a = 0;
            String connect_string = ConfigurationManager.ConnectionStrings["con"].ToString();
            SqlConnection con = new SqlConnection(connect_string);
            con.Open();

            String query = "select * from PHUTHU";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                a = decimal.Parse(dr["KhachThu3"].ToString()) * subtotal;
            }
            con.Close();
            return a;
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                rentFullInfo rentFullInfo = (rentFullInfo)lv_checkin.SelectedItem;

                tb_client_name.Text = rentFullInfo.TenKH.ToString();
                tb_address.Text = rentFullInfo.DiaChi.ToString();
                tb_gender.Text = rentFullInfo.GioiTinh.ToString();
                tb_cmnd.Text = rentFullInfo.CMND.ToString();
                tb_phone.Text = rentFullInfo.SoDienThoai.ToString();
                tb_client_type.Text = rentFullInfo.TenLoaiKhach.ToString();
                tb_room_name.Text = rentFullInfo.TenPhong.ToString();
                tb_room_type.Text = rentFullInfo.TenLoaiPhong.ToString();
                tb_unit_price.Text = rentFullInfo.DonGia.ToString();
                tb_checkin.Text = rentFullInfo.NgayBatDau.ToShortDateString();
                datepicker_checkout.SelectedDate = rentFullInfo.NgayTraPhong;
                tb_client_number.Text = rentFullInfo.SoLuongKhach.ToString();

                tb_days.Text = rentFullInfo.NgayTraPhong.Subtract(rentFullInfo.NgayBatDau).TotalDays.ToString();


                decimal _subtotal = Math.Round(decimal.Parse(rentFullInfo.DonGia.ToString()) * decimal.Parse(tb_days.Text),2);
                tb_subtotal.Text = _subtotal.ToString();

                tb_surcharge.Text = Math.Round(get_surcharge(_subtotal), 2).ToString();

                decimal _deposits = Math.Round(decimal.Parse(rentFullInfo.TienCoc.ToString()),2);
                tb_Deposits.Text = _deposits.ToString();

                decimal _total = Math.Round((_subtotal + Math.Round(get_surcharge(_subtotal), 2) - _deposits), 2);

                tb_total.Text = _total.ToString();
            }
        }
    }
}