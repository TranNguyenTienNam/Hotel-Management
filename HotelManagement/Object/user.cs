using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement
{
    class user
    {
        int maNgDung;
        string userName;
        string ho;
        string ten;
        string soDienThoai;
        string gioiTinh;
        string email;
        DateTime ngaySinh;
        string tinhTrangTK;
        /// <summary>
        /// Permission of Account: 
        /// 0 => Master(Admin)
        /// 1 => Manager
        /// 2 => Staff
        /// </summary>
        int quyenHan;

        public int MaNgDung { get => maNgDung; set => maNgDung = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Ho { get => ho; set => ho = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Email { get => email; set => email = value; }
        public int QuyenHan { get => quyenHan; set => quyenHan = value; }
        public string TinhTrangTK { get => tinhTrangTK; set => tinhTrangTK = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
    }
}