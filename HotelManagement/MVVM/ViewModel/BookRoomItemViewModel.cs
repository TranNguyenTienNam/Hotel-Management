using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Core;
using System.Data;
using HotelManagement.MVVM.Model;
using System.Collections.ObjectModel;
using HotelManagement.Object;
using System.Windows.Input;

namespace HotelManagement.MVVM.ViewModel
{
    public class BookRoomItemViewModel : ObservableObject
    {
        public static BookRoomItemViewModel Instance => new BookRoomItemViewModel();

        public int MaPhong { get; set; }
        public string TenPhong { get; set; }
        public string LoaiPhong { get; set; }
        public int DonGia { get; set; }
        public int SoNgToiDa { get; set; }
        public string GhiChu { get; set; }
    
    }
}
