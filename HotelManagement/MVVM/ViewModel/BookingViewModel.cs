﻿using HotelManagement.Object;
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
    public class BookingViewModel
    {
        public static RoomListViewModel Insance => new RoomListViewModel();
        public List<RoomListItemViewModel> Items { get; set; }

        public BookingViewModel()
        {
            loadListRoom();
        }

        void loadListRoom()
        {
            Items = new List<RoomListItemViewModel>();

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
                    DonGia = (int)row["DonGia"],
                    SoNgToiDa = (int)row["SoNgToiDa"],
                    GhiChu = (row["GhiChu"] != null) ? string.Empty : (string)row["GhiChu"]
                };
                Items.Add(obj);
            }
        }
    }
}
