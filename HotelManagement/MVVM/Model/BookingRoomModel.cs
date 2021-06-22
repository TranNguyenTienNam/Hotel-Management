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
    }
}
