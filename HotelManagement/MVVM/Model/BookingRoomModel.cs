using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.Model
{
    class BookingRoomModel
    {
 
        public DataTable Load_On(string checkin , string checkout)  
        {
            DataTable re;
   
            string sql_select = "SELECT * "
                            + "FROM PHONG p, LOAIPHONG lp "
                            + "WHERE p.MaLoaiPhong = lp.MaLoaiPhong and MaPhong NOT IN(SELECT MaPhong "
                            + "FROM PHIEUTHUEPHONG "
                            + "WHERE (NgayBatDau <= '" + checkin + "' and '" + checkin + "' <= NgayTraPhong) "
                            + "or (NgayBatDau <= '" + checkout + "' and '" + checkout + "' <= NgayTraPhong) "
                            + "or (NgayBatDau >= '" + checkin + "' and '" + checkout + "' >= NgayTraPhong)) ";

            re = Process.createTable(sql_select);
            return re;
        }



        

        public int Save_Client(string TenKH, int MaLoaiKhach,
                               int CMND, int SDT,string DiaChi,
                               string GioiTinh){

            string sql_update = "insert KHACHHANG(TenKH,MaLoaiKhach,CMND,SoDienThoai,DiaChi,GioiTinh) values"
                                + "('" + TenKH + "'," + MaLoaiKhach + "," + CMND + "," + SDT + ",'" + DiaChi 
                                + "','" + GioiTinh + "');SELECT SCOPE_IDENTITY();";

            int i = Process.insertUser(sql_update);
            if (i!=0) return i;
            return 0;
        }

        public bool Save_Booking(int MaPhong, int MaKH,string NgayLapPhieu, 
                                string NgayBatDau,string NgayTraphong,
                                int SoLuongKhach,string TinhTrang,
                                int NguoiLapPhieu,int TienCoc){

            string sql_update = "insert PHIEUTHUEPHONG(MaPhong,MaKH,NgayLapPhieu,NgayBatDau," +
                                "NgayTraPhong,SoLuongKhach,TinhTrang,NguoiLapPhieu,TienCoc) values"
                                + "(" + MaPhong + "," + MaKH + ",'" + NgayLapPhieu + "','" 
                                + NgayBatDau + "','" + NgayTraphong + "'," + SoLuongKhach 
                                + ",'" + TinhTrang + "'," + NguoiLapPhieu + ","+TienCoc+ ")"; 

            if (Process.ExecutiveNonQuery(sql_update) > 0)
                return true;

            return false;
        }
    }
}
