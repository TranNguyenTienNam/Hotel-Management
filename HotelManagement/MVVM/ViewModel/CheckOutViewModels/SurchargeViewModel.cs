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

namespace HotelManagement.MVVM.ViewModel
{
    class SurchargeViewModel : ObservableObject
    {
        public static SurchargeViewModel Instance => new SurchargeViewModel();

        private int _khachThu3;
        public int KhachThu3 { get { return _khachThu3; } set { _khachThu3 = value; OnPropertyChanged(); } }

        public ICommand UpdateSrcharge { get; set; }

        public SurchargeViewModel()
        {
            LoadSurcharge();

            UpdateSrcharge = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                Update(KhachThu3);
            });
        }

        private void Update(int khachThu3)
        {
            if (khachThu3 < 0)
            {
                MessageBox.Show("Phụ thu không được nhỏ hơn 0!");
                LoadSurcharge();
                return;
            }
            SurchargeModel model = new SurchargeModel();
            model.Update_surcharge(khachThu3);
            MessageBox.Show("Update successful!");
        }

        private void LoadSurcharge()
        {
            SurchargeModel model = new SurchargeModel();
            KhachThu3 = model.Get_surcharge_more_client();
        }

    }
}
