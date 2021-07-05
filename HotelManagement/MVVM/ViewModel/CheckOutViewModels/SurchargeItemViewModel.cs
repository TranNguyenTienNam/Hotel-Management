using HotelManagement.Core;
using HotelManagement.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelManagement.MVVM.ViewModel.CheckOutViewModels
{
    class SurchargeItemViewModel :ObservableObject
    {
        public static SurchargeViewModel Instance => new SurchargeViewModel();

        private int _khachThu3;
        public int KhachThu3 { get { return _khachThu3; } set { _khachThu3 = value; OnPropertyChanged(); } }

        private int _khachNuocNgoai;
        public int KhachNuocNgoai { get { return _khachNuocNgoai; } set { _khachNuocNgoai = value; OnPropertyChanged(); } }
    }
}
