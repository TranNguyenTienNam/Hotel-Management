using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.MVVM.Model;
using System.Data;

namespace HotelManagement.MVVM.ViewModel
{
    class BookingListViewModel
    {

        public static BookingListViewModel Insance => new BookingListViewModel();
        public List<BookingItemViewModel> Items { get; set; }

        public BookingListViewModel()
        {
            Items = new List<BookingItemViewModel>();

            BookingListModel model = new BookingListModel();
            DataTable data = new DataTable();
            data = model.Load_On();

            foreach (DataRow row in data.Rows)
            {
                var obj = new BookingItemViewModel()
                {
                    MaPhieuThue = (int)row["MaPhieuThue"],
                    MaPhong = (int)row["MaPhong"],
                    MaKH = (int)row["MaKH"],
                    NgayBatDau = (DateTime)row["NgayBatDau"],
                    NgayLapPhieu = (DateTime)row["NgayLapPhieu"],
                    TienCoc = (decimal)row["TienCoc"],
                    TenKH = (string)row["TenKH"],
                    SoDienThoai = (string)row["SoDienThoai"]


                };
                Items.Add(obj);
            }
            return;
        }

       
    }
}
