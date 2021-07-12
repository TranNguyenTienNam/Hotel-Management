using HotelManagement.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using HotelManagement.Core;
using System.Data;
using HotelManagement.MVVM.Model;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using HotelManagement.MVVM.View;

namespace HotelManagement.MVVM.ViewModel
{
    class StaffViewModel : ObservableObject
    {
        public static StaffViewModel Instance => new StaffViewModel();

        private ObservableCollection<StaffItemViewModel> staff;
        public ObservableCollection<StaffItemViewModel> Staff { get { return staff; } set { staff = value; OnPropertyChanged("Staff"); } }

        private string selectedMode;
        public string SelectedMode { get { return selectedMode; } set { selectedMode = value; OnPropertyChanged("mode"); } }

        private List<string> _itemsSearch;
        public List<string> ItemsSearch { get { return _itemsSearch; } set { _itemsSearch = value; OnPropertyChanged(); } }

        #region Search box element
        //Item search
        private string selectedSearchItem;
        public string SelectedSearchItem { get { return selectedSearchItem; } set { selectedSearchItem = value; OnPropertyChanged(); } }
        //Search text
        private string searchText;
        public string SearchText { get { return searchText; } set { searchText = value; OnPropertyChanged(); } }
        #endregion

        public ICommand RefreshCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public StaffViewModel()
        {
            Staff = new ObservableCollection<StaffItemViewModel>();
            LoadAllAcounts();

            ItemsSearch = new List<string>();
            ItemsSearch.Add("Staff ID");
            ItemsSearch.Add("User Name");
            ItemsSearch.Add("Last Name");
            ItemsSearch.Add("Phone");

            SearchCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(SelectedSearchItem))
                    return false;
                return true;
            }, (p) =>
            {
                SearchStaff();
            });

            RefreshCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (Staff.Count > 0)
                    Staff.Clear();
                SelectedSearchItem = "";
                SearchText = "";
                LoadAllAcounts();
            });
        }
        public DelegateCommand ModeRadCommand
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    SelectedMode = (string)p;
                });
            }
        }

        void SearchStaff()
        {
            switch (SelectedSearchItem)
            {
                case "Staff ID":
                    LoadSearchStaffById(SearchText);
                    break;
                case "User Name":
                    LoadSearchStaffByUserName(SearchText);
                    break;
                case "Last Name":
                    LoadSearchStaffByLastName(SearchText);
                    break;
                case "Phone":
                    LoadSearchStaffByPhone(SearchText);
                    break;
                default:
                    break;
            }
        }

        void LoadData(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                var obj = new StaffItemViewModel()
                {
                    MaNguoiDung = (int)row["MaNguoiDung"],
                    TenTaiKhoan = (string)row["TenTaiKhoan"],
                    TenNhanVien = (string)row["Ten"],
                    SoDienThoai = (row["SoDienThoai"] == DBNull.Value) ? "" : (string)row["SoDienThoai"],
                    GioiTinh = (row["GioiTinh"] == DBNull.Value) ? "" : (string)row["GioiTinh"],
                    Email = (string)row["Email"],
                    NgaySinh = (row["NgaySinh"] == DBNull.Value) ? DateTime.Now.ToString("dd/MM/yyyy") : ((DateTime)row["NgaySinh"]).ToString("dd/MM/yyyy"),
                    QuyenHan = definePosition((int)row["QuyenHan"]),
                    IsPromoted = ((int)row["QuyenHan"] == 2) ? false : true,
                    IsBlocked = ((int)row["TinhTrang"] == 0) ? true : false,
                };
                Staff.Add(obj);
            }
        }

        void LoadAllAcounts()
        {
            if (Staff.Count > 0)
                Staff.Clear();
            DataTable dataTable = new DataTable();
            StaffModel model = new StaffModel();

            dataTable = model.Load_Accounts(SelectedMode);

            LoadData(dataTable);
        }

        void LoadSearchStaffById(string MaNgDung)
        {
            if (Staff.Count > 0)
                Staff.Clear();
            StaffModel model = new StaffModel();
            DataTable data = new DataTable();
            data = model.Search_StaffID(MaNgDung, SelectedMode);

            LoadData(data);
        }

        void LoadSearchStaffByUserName(string TenTK)
        {
            if (Staff.Count > 0)
                Staff.Clear();
            StaffModel model = new StaffModel();
            DataTable data = new DataTable();
            data = model.Search_StaffUsername(TenTK, SelectedMode);

            LoadData(data);
        }

        void LoadSearchStaffByLastName(string Ho)
        {
            if (Staff.Count > 0)
                Staff.Clear();
            StaffModel model = new StaffModel();
            DataTable data = new DataTable();
            data = model.Search_StaffLastName(Ho, SelectedMode);

            LoadData(data);
        }

        void LoadSearchStaffByPhone(string sdt)
        {
            if (Staff.Count > 0)
                Staff.Clear();
            StaffModel model = new StaffModel();
            DataTable data = new DataTable();
            data = model.Search_StaffPhone(sdt, SelectedMode);

            LoadData(data);
        }

        string definePosition(int posNumber)
        {
            string position = "";
            switch (posNumber)
            {
                case 0:
                    position = "Admin";
                    break;
                case 1:
                    position = "Manager";
                    break;
                case 2:
                    position = "Staff";
                    break;
                default:
                    break;
            }

            return position;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (SelectedSearchItem == "" || SelectedSearchItem == null) {
                LoadAllAcounts();
            } 
            else
            {
                SearchStaff();
            }
        }
    }
}
