using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Object
{
    class RentFullItem
    {
        //phiếu thuê
        int maPhieuThue;
        int maPhong;
        int maKH;
        DateTime ngayLapPhieu;
        DateTime ngayBatDau;
        DateTime ngayTraPhong;
        int soLuongKhach;
        string tinhTrang;
        int nguoiLapPhieu;
        int tienCoc;

        public int MaPhieuThue { get => maPhieuThue; set => maPhieuThue = value; }
        public int MaPhong { get => maPhong; set => maPhong = value; }
        public int MaKH { get => maKH; set => maKH = value; }
        public DateTime NgayLapPhieu { get => ngayLapPhieu; set => ngayLapPhieu = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayTraPhong { get => ngayTraPhong; set => ngayTraPhong = value; }
        public int SoLuongKhach { get => soLuongKhach; set => soLuongKhach = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public int NguoiLapPhieu { get => nguoiLapPhieu; set => nguoiLapPhieu = value; }
        public int TienCoc { get => tienCoc; set => tienCoc = value; }

        //khách hàng
        string tenKH;
        string loaiKhach;
        string cMND;
        string soDienThoai;
        string diaChi;
        string gioiTinh;

        public string TenKH { get => tenKH; set => tenKH = value; }
        public string LoaiKhach { get => loaiKhach; set => loaiKhach = value; }
        public string CMND { get => cMND; set => cMND = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }

        //loại khách hàng
        int maLoaiKhach;
        string tenLoaiKhach;

        public int MaLoaiKhach { get => maLoaiKhach; set => maLoaiKhach = value; }
        public string TenLoaiKhach { get => tenLoaiKhach; set => tenLoaiKhach = value; }

        //phòng
        string tenPhong;
        int donGia;
        int soNgToiDa;
        string ghiChu;

        public string TenPhong { get => tenPhong; set => tenPhong = value; }
        public int DonGia { get => donGia; set => donGia = value; }
        public int SoNgToiDa { get => soNgToiDa; set => soNgToiDa = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }

        //loại phòng
        int maLoaiPhong;
        string tenLoaiPhong;

        public int MaLoaiPhong { get => maLoaiPhong; set => maLoaiPhong = value; }
        public string TenLoaiPhong { get => tenLoaiPhong; set => tenLoaiPhong = value; }
    }
}
