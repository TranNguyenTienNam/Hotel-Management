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
        public DataTable Load_On()  
        {
            DataTable re;
            string sql_select = "select p.MaPhong as MaPhong, p.TenPhong as TenPhong, lp.TenLoaiPhong as TenLoaiPhong, "
                + "lp.DonGia as DonGia, lp.SoNgToiDa as SoNgToiDa, p.GhiChu as GhiChu "
                + "from PHONG p, LOAIPHONG lp "
                + "where p.MaLoaiPhong = lp.MaLoaiPhong";

            re = Process.createTable(sql_select);
            return re;
        }

        public int Save_Client(string TenKH, int MaLoaiKhach, int CMND, int SDT,string DiaChi,string GioiTinh)
        {
            string sql_update = "insert KHACHHANG(TenKH,MaLoaiKhach,CMND,SoDienThoai,DiaChi,GioiTinh) values"
                + "('" + TenKH + "'," + MaLoaiKhach + "," + CMND + "," + SDT + ",'" + DiaChi + "','" + GioiTinh + "');SELECT SCOPE_IDENTITY();";

            int i = Process.insertUser(sql_update);
            if (i!=0) return i;
            return 0;
        }

        public bool Save_Booking(int MaPhong, string TenPhong, int MaLoaiPhong, string GhiChu)
        {
            string sql_update = "insert PHIEUTHUEPHONG(MaPhong,MaKH,NgayLapPhieu,NgayBatDau,NgayTraPhong,SoLuongKhach,TinhTrang,NguoiLapPhieu,TienCoc) values";
             //(102, 1002, 7 / 2 / 2021, 7 / 2 / 2021, 7 / 24 / 2021, 3, 'Checkin', 1001, 200000),
            if (Process.ExecutiveNonQuery(sql_update) > 0)
                return true;

            return false;
        }
    }
}
