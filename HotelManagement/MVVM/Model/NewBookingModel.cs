using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.Model
{
    class NewBookingModel
    {
 
        public DataTable Load_On(string checkin , string checkout)  
        {
            DataTable re;
   
            string sql_select = "SELECT * "
                            + "FROM PHONG p, LOAIPHONG lp "
                            + "WHERE p.MaLoaiPhong = lp.MaLoaiPhong and MaPhong NOT IN(SELECT MaPhong "
                            + "FROM PHIEUTHUEPHONG "
                            + "WHERE ((NgayBatDau <= '" + checkin + "' and '" + checkin + "' <= NgayTraPhong) "
                            + "or (NgayBatDau <= '" + checkout + "' and '" + checkout + "' <= NgayTraPhong) "
                            + "or (NgayBatDau >= '" + checkin + "' and '" + checkout + "' >= NgayTraPhong)) " 
                            + "and (TinhTrang = 'Booked' or TinhTrang= 'Checkin')) ";

            re = Process.createTable(sql_select);
            return re;
        }
        
        public bool Update_Client(string TenKH, int MaLoaiKhach,
                                string CMND,string SDT, string DiaChi,
                                string GioiTinh)
        {
            string sql_update = "UPDATE KHACHHANG " +
                                "SET TenKH = '" + TenKH + "', MaLoaiKhach ="+ MaLoaiKhach +", " +
                                "SoDienThoai = " + SDT + ", DiaChi = '" + DiaChi + "', " +
                                "GioiTinh = '" + GioiTinh + "' WHERE CMND = '" + CMND + "';";

            if (Process.ExecutiveNonQuery(sql_update) > 0)
                return true;
            return false;
        }
        
        
        public DataTable CheckInfo(string CitizenID)  
        {
            DataTable re;
            string sql_select = "SELECT * FROM KHACHHANG WHERE CMND = '" + CitizenID + "'";                           
            re = Process.createTable(sql_select);
            return re;
        }



        

        
        public bool Save_Client(string TenKH, int MaLoaiKhach,
                               string CMND, string SDT,string DiaChi,
                               string GioiTinh){

            string sql_update = "insert KHACHHANG(TenKH,MaLoaiKhach,CMND,SoDienThoai,DiaChi,GioiTinh) values"
                                + "('" + TenKH + "'," + MaLoaiKhach + ",'" + CMND + "'," + SDT + ",'" + DiaChi 
                                + "','" + GioiTinh + "')";

            if (Process.ExecutiveNonQuery(sql_update) > 0)
                return true;
            return false;
        }


        public bool Save_Booking(int MaPhong, string CMND,string NgayLapPhieu, 
                                string NgayBatDau,string NgayTraphong,
                                string SoLuongKhach,string TinhTrang,
                                int NguoiLapPhieu,string TienCoc){

            string sql_update = "insert PHIEUTHUEPHONG(MaPhong,CMND,NgayLapPhieu,NgayBatDau," +
                                "NgayTraPhong,SoLuongKhach,TinhTrang,NguoiLapPhieu,TienCoc) values"
                                + "(" + MaPhong + ",'" + CMND + "','" + NgayLapPhieu + "','" 
                                + NgayBatDau + "','" + NgayTraphong + "'," + SoLuongKhach 
                                + ",'" + TinhTrang + "'," + NguoiLapPhieu + ","+TienCoc+ ")"; 

            if (Process.ExecutiveNonQuery(sql_update) > 0)
                return true;

            return false;
        }
    }
}
