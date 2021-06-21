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
    class RoomListModel
    {
        public DataTable Load_On()   //Đầu vào cần 1 mã Ukey 
        {
            DataTable re;
            string sql_select = "select p.MaPhong as MaPhong, p.TenPhong as TenPhong, lp.TenLoaiPhong as TenLoaiPhong, "
                + "lp.DonGia as DonGia, lp.SoNgToiDa as SoNgToiDa, p.GhiChu as GhiChu "
                + "from PHONG p, LOAIPHONG lp "
                + "where p.MaLoaiPhong = lp.MaLoaiPhong";

            re = Process.createTable(sql_select);
            return re;  //Trả về 1 DataTable hàng hóa có số lượng hàng hóa > 0
        }
        
        public bool Save_RoomEdited(int MaPhong, string TenPhong, int MaLoaiPhong, string GhiChu)
        {
            string sql_update = "update PHONG set TenPhong = N'" + TenPhong + "', " +
                "MaLoaiPhong = " + MaLoaiPhong + ", GhiChu = N'" + GhiChu + "' where MaPhong = " + MaPhong;

            try
            {
                if (Process.ExecutiveNonQuery(sql_update) > 0)
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        
    }
}
