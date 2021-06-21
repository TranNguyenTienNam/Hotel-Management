using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Object
{
    class userInfo
    {
        int maNgDung;
        string ho;
        string ten;
        string soDienThoai;
        string gioiTinh;
        string email;
        DateTime ngaySinh;
        int quyenHan;

        public int MaNgDung { get => maNgDung; set => maNgDung = value; }
        public string Ho { get => ho; set => ho = value; }
        public string Ten { get => ten; set => ten = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string Email { get => email; set => email = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public int QuyenHan { get => quyenHan; set => quyenHan = value; }

    }
}
