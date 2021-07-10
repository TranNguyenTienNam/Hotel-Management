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

namespace HotelManagement.MVVM.ViewModel.CheckOutViewModels
{
    class SurchargeViewModel : ObservableObject
    {
        public static SurchargeViewModel Instance => new SurchargeViewModel();
        private ObservableCollection<SurchargeItemViewModel> _items;
        public ObservableCollection<SurchargeItemViewModel> Items { get { return _items; } set { _items = value; OnPropertyChanged("Items"); } }

        public ICommand UpdateSrcharge { get; set; }

        public SurchargeViewModel()
        {
            LoadSurcharge();

        }

        void LoadSurcharge()
        {
            Items = new ObservableCollection<SurchargeItemViewModel>();
            DataTable data = new DataTable();
            SurchargeModel model = new SurchargeModel();

            data = model.load_surcharge();

            foreach (DataRow row in data.Rows)
            {
                var obj = new SurchargeItemViewModel()
                {
                    KhachThu3 = (int)row["KhachThu3"],
                    KhachNuocNgoai = (int)row["KhachNuocNgoai"]
                };
                Items.Add(obj);
            }
        }

    }
}
