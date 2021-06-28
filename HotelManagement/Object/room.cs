using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Object
{
    public class room
    {
        int maPhong;
        string tenPhong;
        string loaiPhong;
        decimal donGia;
        int soNgToiDa;
        string ghiChu;       

        public int MaPhong { get => maPhong; set => maPhong = value; }
        public string TenPhong { get => tenPhong; set => tenPhong = value; }
        public string LoaiPhong { get => loaiPhong; set => loaiPhong = value; }
        public decimal DonGia { get => donGia; set => donGia = value; }
        public int SoNgToiDa { get => soNgToiDa; set => soNgToiDa = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}