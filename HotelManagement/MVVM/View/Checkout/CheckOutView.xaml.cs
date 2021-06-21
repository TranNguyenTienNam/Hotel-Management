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
        private decimal get_surcharge(decimal subtotal, int clients, int rent)
        {
            decimal re = 0;
            decimal tilephuthu=0;
            int songtoida = 0;


            String connect_string = ConfigurationManager.ConnectionStrings["con"].ToString();
            SqlConnection con = new SqlConnection(connect_string);

            con.Open();
            String query = "select * from PHUTHU";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                tilephuthu = decimal.Parse(dr["KhachThu3"].ToString());
            }

            string query1 = "select SoNgToiDa" +
                "from PHIEUTHUEPHONG" +
                "join PHONG on PHONG.MaPhong=PHIEUTHUEPHONG.MaPhong" +
                "join LOAIPHONG on LOAIPHONG.MaLoaiPhong=PHONG.MaLoaiPhong" +
                "where PHIEUTHUEPHONG.MaPhieuThue=" +
                rent.ToString();
            con.Close();
            con.Open();
            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if(dr1.Read())
            {
 ////               songtoida = int.Parse(dr1["SoNguoiToiDa"].ToString());
            }
            con.Close();
            if(clients > songtoida)
            {
                re = (clients - songtoida) * tilephuthu * subtotal;
            }
            return re;
        }
        int maphieuthue = 0;
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

                tb_surcharge.Text = Math.Round(get_surcharge(_subtotal,rentFullInfo.SoLuongKhach,rentFullInfo.MaPhieuThue), 2).ToString();

                decimal _deposits = Math.Round(decimal.Parse(rentFullInfo.TienCoc.ToString()),2);
                tb_Deposits.Text = _deposits.ToString();

                decimal _total = Math.Round((_subtotal + Math.Round(get_surcharge(_subtotal, rentFullInfo.SoLuongKhach, rentFullInfo.MaPhieuThue), 2) - _deposits), 2);

                tb_total.Text = _total.ToString();

                maphieuthue = rentFullInfo.MaPhieuThue;
            }
        }
            
        private void datepicker_checkout_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if(DateTime.Parse(datepicker_checkout.SelectedDate.ToString())<DateTime.Parse(tb_checkin.Text))
            {
                MessageBox.Show("Check-out date must be >= check-in date !");
            }
            else
            {
                DateTime new_checkout = datepicker_checkout.SelectedDate.Value;
                //MessageBox.Show(new_checkout.ToString());

                tb_days.Text = new_checkout.Subtract(DateTime.Parse(tb_checkin.Text)).TotalDays.ToString();

                decimal _subtotal = Math.Round(decimal.Parse(tb_unit_price.Text) * decimal.Parse(tb_days.Text), 2);
                tb_subtotal.Text= _subtotal.ToString();

                decimal _deposits = Math.Round(decimal.Parse(tb_Deposits.Text), 2);
                tb_Deposits.Text = _deposits.ToString();

                decimal _total = Math.Round((_subtotal + Math.Round(get_surcharge(_subtotal, int.Parse(tb_client_number.Text.ToString()), maphieuthue), 2) - _deposits), 2);

                tb_total.Text = _total.ToString();
            }
        }
    }
}