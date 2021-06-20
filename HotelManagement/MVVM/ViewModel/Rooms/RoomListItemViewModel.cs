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
using HotelManagement.MVVM.View;

namespace HotelManagement.MVVM.ViewModel
{
    public class RoomListItemViewModel : ObservableObject
    {
        public static RoomListItemViewModel Instance => new RoomListItemViewModel();

        public int MaPhong { get; set; }
        public string TenPhong { get; set; }
        public string LoaiPhong { get; set; }
        public decimal DonGia { get; set; }
        public int SoNgToiDa { get; set; }
        public string GhiChu { get; set; }

        public bool IsSelected { get; set; }

        public ICommand EditRoomCommand { get; set; }

        public RoomListItemViewModel()
        {
            MaPhong = 1000;
            TenPhong = "Phong VIP";
            LoaiPhong = "Deluxe (DLX)";
            DonGia = (decimal)750000.0000;
            SoNgToiDa = 3;
            GhiChu = "";

            EditRoomCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) => 
            {
                EditRoomView wd = new EditRoomView();
                wd.ShowDialog();
            });
        }
    }
}
