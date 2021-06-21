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
using System.Windows.Controls;

namespace HotelManagement.MVVM.ViewModel
{
    public class RoomListViewModel : ObservableObject
    {
        public static RoomListViewModel Instance => new RoomListViewModel();
        private ObservableCollection<RoomListItemViewModel> _items;
        public ObservableCollection<RoomListItemViewModel> Items { get { return _items; } set { _items = value; OnPropertyChanged("Items"); } }

        public ICommand refreshListRoom { get; set; }
        public ICommand MouseWheelCommand { get; set; }

        public RoomListViewModel()
        {
            Items = new ObservableCollection<RoomListItemViewModel>();
            loadListRoom();

            refreshListRoom = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                //Items.Remove(Items.Where(X => X.MaPhong == 144).Single());
                loadListRoom();
            });
        }

        public void loadListRoom()
        {
            if (Items.Count > 0)
                Items.Clear();
            RoomsListModel model = new RoomsListModel();
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
                    GhiChu = (row["GhiChu"] == DBNull.Value) ? "" : (string)row["GhiChu"]
                };
                Items.Add(obj);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            switch (propertyName)
            {
                case "Items":
                    {
                        loadListRoom();
                    }
                    break;
                default:
                    break;
            }
        }
    } 
}
