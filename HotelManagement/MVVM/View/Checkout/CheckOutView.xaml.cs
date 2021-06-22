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
        private decimal get_surcharge(decimal subtotal, int clients, int rentid)
        {
            decimal re = 0;
            decimal tilephuthu=0;
            int songtoida = 0;

            String connect_string = ConfigurationManager.ConnectionStrings["con"].ToString();
            SqlConnection con = new SqlConnection(connect_string);
            //get tỉ lệ phụ thu
            con.Open();
            String query = "select * from PHUTHU";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                tilephuthu = decimal.Parse(dr["KhachThu3"].ToString());
            }
            con.Close();
            //get số người tối đa của phòng
            con.Open();
            string query1 = "select SoNgToiDa " +
                "from PHIEUTHUEPHONG " +
                "join PHONG on PHONG.MaPhong=PHIEUTHUEPHONG.MaPhong " +
                "join LOAIPHONG on LOAIPHONG.MaLoaiPhong=PHONG.MaLoaiPhong " +
                "where PHIEUTHUEPHONG.MaPhieuThue= " +
                rentid +" ;";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if(dr1.Read())
            {
                songtoida = int.Parse(dr1["SoNgToiDa"].ToString());
            }
            con.Close();
            //tính phụ ( quá tối đa bao nhiêu người * tỉ lệ * đơn giá )
            if(clients > songtoida)
            {
                re = (clients - songtoida) * tilephuthu * subtotal;
            }
            return re;
        }

        int maphieuthue = 0;
        //show thông tin khi click vào 1 hàng
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
                //tính số ngày ở
                tb_days.Text = rentFullInfo.NgayTraPhong.Subtract(rentFullInfo.NgayBatDau).TotalDays.ToString();
                //tính subtotal
                decimal _subtotal = rentFullInfo.DonGia * decimal.Parse(tb_days.Text);
                tb_subtotal.Text = Math.Round(_subtotal,2).ToString();
                //tính phụ thu
                decimal _surcharge = get_surcharge(_subtotal, rentFullInfo.SoLuongKhach, rentFullInfo.MaPhieuThue);
                tb_surcharge.Text = Math.Round(_surcharge, 2).ToString();
                //tiền cọc
                decimal _deposits = rentFullInfo.TienCoc;
                tb_Deposits.Text = Math.Round(_deposits,2).ToString();
                //tính tổng tiền
                decimal _total = _subtotal + _surcharge - _deposits;
                tb_total.Text = Math.Round(_total,2).ToString();
                //gán mã phiếu thuê vào biến đễ dễ truy xuất ngoài hàm
                maphieuthue = rentFullInfo.MaPhieuThue;
            }
        }
        DateTime newcheckout = DateTime.Now.Date;
        int days = 0;
        decimal subtotal = 0;
        decimal surcharge = 0;
        decimal total = 0;
        //sau khi chọn ngày checkout ( khi khách trả phòng sớm hơn lúc ban đầu đã book)
        private void datepicker_checkout_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if(DateTime.Parse(datepicker_checkout.SelectedDate.ToString())<DateTime.Parse(tb_checkin.Text))
            {
                MessageBox.Show("Check-out date must be >= check-in date !");
            }
            else
            {
                DateTime new_checkout = datepicker_checkout.SelectedDate.Value;

                //tính lại số ngày ở
                int _days = int.Parse(new_checkout.Subtract(DateTime.Parse(tb_checkin.Text)).TotalDays.ToString());
                tb_days.Text = _days.ToString();
                //tính lại subtotal ( số ngày ở * đơn giá)
                decimal _subtotal = decimal.Parse(tb_unit_price.Text) * decimal.Parse(tb_days.Text);
                tb_subtotal.Text= Math.Round(_subtotal,2).ToString();
                //tiền cọc 
                decimal _deposits = decimal.Parse(tb_Deposits.Text);
                //tính lại phụ thu
                int clients = int.Parse(tb_client_number.Text);
                decimal _surcharge = get_surcharge(_subtotal, clients, maphieuthue);
                tb_surcharge.Text = Math.Round(_surcharge, 2).ToString();
                //tính lại tổng tiền 
                decimal _total = _subtotal +_surcharge  - _deposits;
                tb_total.Text = Math.Round(_total,2).ToString();
                //set các giá trị đã thay đổi vào biến toàn cục để dễ update lại phiếu thuê và tạo hóa đơn
                newcheckout = new_checkout;
                days = _days;
                subtotal = _subtotal;
                surcharge = _surcharge;
                total = _total;
            }
        }
    }
}