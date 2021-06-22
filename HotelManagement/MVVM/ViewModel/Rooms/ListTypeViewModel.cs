using HotelManagement.Core;
using HotelManagement.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HotelManagement.MVVM.ViewModel
{
    class ListTypeViewModel : ObservableObject
    {
        public static ListTypeViewModel Instance => new ListTypeViewModel();
        private ObservableCollection<ListTypeItemViewModel> _items;
        public ObservableCollection<ListTypeItemViewModel> Items { get { return _items; } set { _items = value; OnPropertyChanged("Items"); } }

        public ICommand RefreshListRoom { get; set; }

        public ListTypeViewModel()
        {
            Items = new ObservableCollection<ListTypeItemViewModel>();
            loadListItem();

            RefreshListRoom = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                loadListItem();
            });
        }

        void loadListItem()
        {
            if (Items.Count > 0)
                Items.Clear();
            TypesListModel model = new TypesListModel();
            DataTable data = new DataTable();
            data = model.Load_On();
            foreach (DataRow row in data.Rows)
            {
                var obj = new ListTypeItemViewModel()
                {
                    Id = (int)row["MaLoaiPhong"],
                    TypeName = (string)row["TenLoaiPhong"],
                    Price = (decimal)row["DonGia"],
                    MaxPeople = (int)row["SoNgToiDa"]
                };
                Items.Add(obj);
            }
        }
    }
}
