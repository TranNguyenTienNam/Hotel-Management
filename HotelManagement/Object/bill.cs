using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Object
{
    class bill
    {
        int maHoaDon;
        int maPhieuThue;
        decimal phuThu;
        decimal tongTien;

        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public int MaPhieuThue { get => maPhieuThue; set => maPhieuThue = value; }
        public decimal PhuThu { get => phuThu; set => phuThu = value; }
        public decimal TongTien { get => tongTien; set => tongTien = value; }
    }
}
