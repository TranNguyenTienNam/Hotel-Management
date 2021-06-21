using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Object
{
    class rent
    {
        int maPhieuThue;
        int maPhong;
        int maKH;
        DateTime ngayBatDau;
        DateTime ngayTraPhong;
        int soLuongKhach;
        string tinhTrang;
        int nguoiLapPhieu;
        decimal tienCoc;

        public int MaPhieuThue { get => maPhieuThue; set => maPhieuThue = value; }
        public int MaPhong { get => maPhong; set => maPhong = value; }
        public int MaKH { get => maKH; set => maKH = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayTraPhong { get => ngayTraPhong; set => ngayTraPhong = value; }
        public int SoLuongKhach { get => soLuongKhach; set => soLuongKhach = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public int NguoiLapPhieu { get => nguoiLapPhieu; set => nguoiLapPhieu = value; }
        public decimal TienCoc { get => tienCoc; set => tienCoc = value; }
    }
}
