using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.Model
{
    class ProfileModel
    {
        public user Load_Profile(int MaNgDung)
        {
            string sql_select = "select TTNguoiDung.MaNgDung, Ho, Ten, SoDienThoai, GioiTinh, Email, NgaySinh, QuyenHan, NGUOIDUNG.TenTaiKhoan, TinhTrangTK " +
                "from TTNguoiDung inner join NGUOIDUNG on TTNguoiDung.MaNgDung = NGUOIDUNG.MaNgDung " +
                "where TTNguoiDung.MaNgDung = " + MaNgDung;

            return Process.getInfo(sql_select);
        }
    }
}
