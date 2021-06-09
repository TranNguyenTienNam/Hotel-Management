using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.Model
{
    class RoomsModel
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

    }
}
