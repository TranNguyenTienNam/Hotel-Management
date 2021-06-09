using HotelManagement.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Core;
using System.Data;
using HotelManagement.MVVM.Model;

namespace HotelManagement.MVVM.ViewModel
{
    class RoomsViewModel : ObservableObject
    {
        private ObservableCollection<room> _rooms;
        public ObservableCollection<room> rooms { get => _rooms; set { _rooms = value; OnPropertyChanged(); } }

        public RoomsViewModel()
        {
            loadListRoom();
        }

        void loadListRoom()
        {
            rooms = new ObservableCollection<room>();

            RoomsModel model = new RoomsModel();
            DataTable data = new DataTable();
            data = model.Load_On();

            foreach (DataRow row in data.Rows)
            {
                var obj = new room()
                {
                    MaPhong = (int)row["MaPhong"],
                    TenPhong = (string)row["TenPhong"],
                    LoaiPhong = (string)row["TenLoaiPhong"],
                    DonGia = (decimal)row["DonGia"],
                    SoNgToiDa = (int)row["SoNgToiDa"],
                    GhiChu = (row["GhiChu"] != null) ? string.Empty : (string)row["GhiChu"]
                };
                rooms.Add(obj);
            }
        }
    }
}
