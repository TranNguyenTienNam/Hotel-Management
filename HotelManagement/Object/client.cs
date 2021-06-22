using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Object
{
    class client
    {
        string maKH;
        string tenKH;
        string loaiKhach;
        string cMND;
        string soDienThoai;
        string diaChi;
        string gioiTinh;

        public string MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string LoaiKhach { get => loaiKhach; set => loaiKhach = value; }
        public string CMND { get => cMND; set => cMND = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
    }
}