using HotelManagement.Core;
using HotelManagement.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace HotelManagement.MVVM.ViewModel
{
    /// <summary>
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public class ProfileViewModel : ObservableObject
    {
        private List<string> _listGender;
        public List<string> ListGender { get { return _listGender; } set { _listGender = value; OnPropertyChanged(); } }

        //Họ của người dùng
        private string _firstName;
        public string FirstName { get { return _firstName; } set { _firstName = value; OnPropertyChanged(); } }

        //Tên của người dùng
        private string _lastName;
        public string LastName { get { return _lastName; } set { _lastName = value; OnPropertyChanged(); } }

        //Sđt của người dùng
        private string _phone;
        public string Phone { get { return _phone; } set { _phone = value; OnPropertyChanged(); } }
        
        //Giới tính của người dùng
        private string _gender;
        public string Gender { get { return _gender; } set { _gender = value; OnPropertyChanged(); } }
        
        //Giới tính của người dùng
        private DateTime _birthday;
        public DateTime Birthday { get { return _birthday; } set { _birthday = value; OnPropertyChanged(); } }

        //Email của người dùng
        private string _email;
        public string Email { get { return _email; } set { _email = value; OnPropertyChanged(); } }
        
        //Chức vụ (Quyền hạn) của người dùng
        private string _position;
        public string Position { get { return _position; } set { _position = value; OnPropertyChanged(); } }

        public ICommand SaveProfileCommand { get; set; }

        public ProfileViewModel(int UserId)
        {
            ListGender = new List<string>();
            ListGender.Add("Male");
            ListGender.Add("Female");
            ListGender.Add("Other");
            loadProfile(UserId);

            SaveProfileCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName)
                    || string.IsNullOrEmpty(Phone) || string.IsNullOrEmpty(Email))
                    return false;
                return true;
            }, (p) => 
            { 
                
            });
        }

        void loadProfile(int UserId)
        {
            ProfileModel model = new ProfileModel();
            user user = model.Load_Profile(UserId);

            //MessageBox.Show(user.NgaySinh.ToString());

            FirstName = user.Ho;
            LastName = user.Ten;
            Phone = user.SoDienThoai;
            if (user.GioiTinh != null)
                Gender = user.GioiTinh;
            else
                Gender = "Other";

            if (user.NgaySinh != null)
                Birthday = user.NgaySinh;
            else
                Birthday = DateTime.Now;

            Email = user.Email;
            Position = definePosition(user.QuyenHan);
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
    }
}
