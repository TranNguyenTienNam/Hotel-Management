using HotelManagement.Core;
using HotelManagement.MVVM.Model;
using HotelManagement.MVVM.Model.CheckOut;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HotelManagement.Object;
using System.Data.SqlClient;
using System.Configuration;

namespace HotelManagement.MVVM.ViewModel.CheckOutViewModels
{
    class SurchargeViewModel : ObservableObject
    {
        public static SurchargeViewModel Instance => new SurchargeViewModel();
        private surcharge _items;
        public surcharge Items { get { return _items; } set { _items = value; OnPropertyChanged("Items"); } }

        private int _khachThu3;
        public int KhachThu3 { get { return _khachThu3; } set { _khachThu3 = value; OnPropertyChanged(); } }

        private int _khachNuocNgoai;
        public int KhachNuocNgoai { get { return _khachNuocNgoai; } set { _khachNuocNgoai = value; OnPropertyChanged(); } }

        public ICommand UpdateSrcharge { get; set; }

        public SurchargeViewModel()
        {
            LoadSurcharge();

        }

        private void LoadSurcharge()
        {
            
        }

    }
}
