using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Core;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.ViewModel
{
    public class BookingItemViewModel : ObservableObject
    {
        public int MaPhieuThue { get; set; }
        public int MaPhong { get; set; }
        public string CMND { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayLapPhieu { get; set; }
        public int TienCoc { get; set; }
        public string TenKH { get; set; }
        public string SoDienThoai { get; set; }
        public string TinhTrang { get; set; }
    }
}
