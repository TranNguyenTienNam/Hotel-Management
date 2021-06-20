using HotelManagement.Object;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Core;
using System.Data;
using HotelManagement.MVVM.Model;
using System.Windows.Input;
using System.Windows;

namespace HotelManagement.MVVM.ViewModel
{
    public class RoomListViewModel : ObservableObject
    {
        public static RoomListViewModel Instance => new RoomListViewModel();
        private ObservableCollection<RoomListItemViewModel> _items;
        public ObservableCollection<RoomListItemViewModel> Items { get { return _items; } set { _items = value; OnPropertyChanged(); } }

        public ICommand refreshListRoom { get; set; }

        public RoomListViewModel()
        {
            loadListRoom();

            refreshListRoom = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                loadListRoom();
            });
        }

        public void loadListRoom()
        {
            Items = new ObservableCollection<RoomListItemViewModel>();

            RoomListModel model = new RoomListModel();
            DataTable data = new DataTable();
            data = model.Load_On();

            foreach (DataRow row in data.Rows)
            {
                var obj = new RoomListItemViewModel()
                {
                    MaPhong = (int)row["MaPhong"],
                    TenPhong = (string)row["TenPhong"],
                    LoaiPhong = (string)row["TenLoaiPhong"],
                    DonGia = (decimal)row["DonGia"],
                    SoNgToiDa = (int)row["SoNgToiDa"],
                    GhiChu = (row["GhiChu"] != null) ? string.Empty : (string)row["GhiChu"]
                };
                Items.Add(obj);
            }
        }
    } 
}
