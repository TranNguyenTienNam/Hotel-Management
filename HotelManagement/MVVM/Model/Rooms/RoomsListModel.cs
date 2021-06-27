using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HotelManagement.MVVM.ViewModel;
using System.Windows;

namespace HotelManagement.MVVM.Model
{
    class RoomsListModel
    {
        public DataTable Load_On()   //Đầu vào cần 1 mã Ukey 
        {
            DataTable re;
            string sql_select = "select p.MaPhong as MaPhong, p.TenPhong as TenPhong, lp.TenLoaiPhong as TenLoaiPhong, "
                + "lp.DonGia as DonGia, lp.SoNgToiDa as SoNgToiDa, p.GhiChu as GhiChu "
                + "from PHONG p, LOAIPHONG lp "
                + "where p.MaLoaiPhong = lp.MaLoaiPhong";

            re = Process.createTable(sql_select);
            return re;  //Trả về 1 DataTable
        }
        
        public bool Save_RoomEdited(int MaPhong, string TenPhong, int MaLoaiPhong, string GhiChu)
        {
            string sql_update = "update PHONG set TenPhong = N'" + TenPhong + "', " +
                "MaLoaiPhong = " + MaLoaiPhong + ", GhiChu = N'" + GhiChu + "' where MaPhong = " + MaPhong;

            if (Process.ExecutiveNonQuery(sql_update) > 0)
                return true;

            return false;
        }
        
        public DataTable GetRoom(int MaPhong)
        {
            DataTable re;
            string sql_select = "select p.MaPhong as MaPhong, p.TenPhong as TenPhong, lp.TenLoaiPhong as TenLoaiPhong, "
                + "lp.DonGia as DonGia, lp.SoNgToiDa as SoNgToiDa, p.GhiChu as GhiChu "
                + "from PHONG p, LOAIPHONG lp "
                + "where p.MaLoaiPhong = lp.MaLoaiPhong and p.MaPhong = " + MaPhong;

            re = Process.createTable(sql_select);
            return re;  //Trả về 1 DataTable
        }

        public bool RemoveRoom(int MaPhong)
        {
            string sql_delete = "delete from PHONG where MaPhong= " + MaPhong;

            if (Process.ExecutiveNonQuery(sql_delete) > 0)
                return true;
            return false;
        }

        public DataTable Search_RoomID(string MaPhong)
        {
            DataTable re;
            string sql_select = "select p.MaPhong as MaPhong, p.TenPhong as TenPhong, lp.TenLoaiPhong as TenLoaiPhong, "
                + "lp.DonGia as DonGia, lp.SoNgToiDa as SoNgToiDa, p.GhiChu as GhiChu "
                + "from PHONG p, LOAIPHONG lp "
                + "where p.MaLoaiPhong = lp.MaLoaiPhong and CHARINDEX('" + MaPhong + "', p.MaPhong) != 0";
            re = Process.createTable(sql_select);
            return re;
        }

        public DataTable Search_RoomName(string TenPhong)
        {
            DataTable re;
            string sql_select = "select p.MaPhong as MaPhong, p.TenPhong as TenPhong, lp.TenLoaiPhong as TenLoaiPhong, "
                + "lp.DonGia as DonGia, lp.SoNgToiDa as SoNgToiDa, p.GhiChu as GhiChu "
                + "from PHONG p, LOAIPHONG lp "
                + "where p.MaLoaiPhong = lp.MaLoaiPhong and CHARINDEX(N'" + TenPhong + "', p.TenPhong) != 0";
            re = Process.createTable(sql_select);
            return re;
        }
    }
}
