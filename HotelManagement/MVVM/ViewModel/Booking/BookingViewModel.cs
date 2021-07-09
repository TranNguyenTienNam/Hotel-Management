using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.MVVM.Model;
using System.Data;
using HotelManagement.Core;

namespace HotelManagement.MVVM.ViewModel
{
    class BookingViewModel : ObservableObject
    {
        private List<BookingItemViewModel> _items;
        public List<BookingItemViewModel> Items { get { return _items; } set { _items = value; OnPropertyChanged(); } }

        public BookingViewModel()
        {
            Items = new List<BookingItemViewModel>();

            LoadBooking();
        }

        void LoadBooking()
        {
            if (Items.Count > 0)
                Items.Clear();

            BookingListModel model = new BookingListModel();
            DataTable data = new DataTable();
            data = model.Load_On();

            foreach (DataRow row in data.Rows)
            {
                var obj = new BookingItemViewModel()
                {
                    MaPhieuThue = (int)row["MaPhieuThue"],
                    MaPhong = (int)row["MaPhong"],
                    CMND = (string)row["CMND"],
                    NgayBatDau = (DateTime)row["NgayBatDau"],
                    NgayLapPhieu = (DateTime)row["NgayLapPhieu"],
                    TienCoc = (int)row["TienCoc"],
                    TenKH = (string)row["TenKH"],
                    SoDienThoai = (string)row["SoDienThoai"],
                };
                Items.Add(obj);
            }
        }
    }
}
