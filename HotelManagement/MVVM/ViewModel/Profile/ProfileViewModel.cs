using HotelManagement.Core;
using HotelManagement.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
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

        #region Profile
        private string _firstName;
        public string FirstName { get { return _firstName; } set { _firstName = value; OnPropertyChanged(); } }

        private string _lastName;
        public string LastName { get { return _lastName; } set { _lastName = value; OnPropertyChanged(); } }

        private string _phone;
        public string Phone { get { return _phone; } set { _phone = value; OnPropertyChanged(); } }
        
        private string _gender;
        public string Gender { get { return _gender; } set { _gender = value; OnPropertyChanged(); } }
        
        private DateTime _birthday;
        public DateTime Birthday { get { return _birthday; } set { _birthday = value; OnPropertyChanged(); } }

        private string _email;
        public string Email { get { return _email; } set { _email = value; OnPropertyChanged(); } }

        //label notice invalid email
        private string _noticeInvalidEmail;
        public string NoticeInvalidEmail { get { return _noticeInvalidEmail; } set { _noticeInvalidEmail = value; OnPropertyChanged(); } }
        
        private string _position;
        public string Position { get { return _position; } set { _position = value; OnPropertyChanged(); } }
        #endregion

        #region Change Password
        //label notice when change password error
        private string _changePasswordError;
        public string ChangePasswordError { get { return _changePasswordError; } set { _changePasswordError = value; OnPropertyChanged(); } }

        private string _currentPassword;
        public string CurrentPassword { get { return _currentPassword; } set { _currentPassword = value; OnPropertyChanged(); } }

        private string _newPassword;
        public string NewPassword { get { return _newPassword; } set { _newPassword = value; OnPropertyChanged(); } }

        private string _confirmPassword;
        public string ConfirmPassword { get { return _confirmPassword; } set { _confirmPassword = value; OnPropertyChanged(); } }

        //label notice special char Password
        private string _specialCharCurrentPassword;
        public string SpecialCharCurrentPassword { get { return _specialCharCurrentPassword; } set { _specialCharCurrentPassword = value; OnPropertyChanged(); } }
        
        //label notice special char New Password
        private string _specialCharNewPassword;
        public string SpecialCharNewPassword 
        { 
            get 
            { 
                return _specialCharNewPassword; 
            } 
            set 
            { 
                _specialCharNewPassword = value; 
                OnPropertyChanged(); 
            } 
        }

        //label notice special char Confirm Password
        private string _specialCharConfirmPassword;
        public string SpecialCharConfirmPassword
        {
            get
            {
                return _specialCharConfirmPassword;
            }
            set
            {
                _specialCharConfirmPassword = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public ICommand SaveProfileCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand EmailTextChangedCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand NewPasswordChangedCommand { get; set; }
        public ICommand ConfirmPasswordChangedCommand { get; set; }

        public ProfileViewModel(int UserId)
        {
            ListGender = new List<string>();
            ListGender.Add("Male");
            ListGender.Add("Female");
            ListGender.Add("Other");
            ChangePasswordError = "";
            SpecialCharCurrentPassword = "";
            SpecialCharNewPassword = "";
            SpecialCharConfirmPassword = "";
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


            /// <summary>
            /// ChangePasswordCommand have 3 parameter (object[])
            /// 0 => <include file='ProfileView.xaml' path='[@ElementName="txtPassword"]'/>
            /// 1 => <include file='ProfileView.xaml' path='[@ElementName="txtNewPassword"]'/>
            /// 2 => <include file='ProfileView.xaml' path='[@ElementName="txtConfirmPassword"]'/>
            /// </summary>
            ChangePasswordCommand = new RelayCommand<object[]>((p) =>
            {
                if (string.IsNullOrEmpty(CurrentPassword) || string.IsNullOrEmpty(NewPassword) || string.IsNullOrEmpty(ConfirmPassword))
                    return false;
                if (SpecialCharCurrentPassword != "" || SpecialCharNewPassword != "" || SpecialCharConfirmPassword != "")
                    return false;
                return true;
            }, (p) =>
            {
                ProfileModel model = new ProfileModel();

                if (NewPassword != ConfirmPassword)
                {
                    ChangePasswordError = "New password and confirm password are different";
                    return;
                }    

                if (!model.CheckCurrentPassword(UserId, CurrentPassword))   //Current Password wrong
                {
                    ChangePasswordError = "Current password is wrong";
                    return;
                }
                else
                {
                    //Get array parameter
                    var values = (object[])p;

                    if (model.ChangePassword(UserId, ConfirmPassword))
                    {
                        ChangePasswordError = "Password change success!";
                        
                        foreach (var value in values)
                        {
                            var pwbox = value as PasswordBox;
                            pwbox.Password = "";
                        }    
                    }    
                }
            });

            EmailTextChangedCommand = new RelayCommand<TextBox>((p) =>
            {
                return true;
            }, (p) => 
            {
                RegisterModel model = new RegisterModel();
                if (!model.IsValidEmail(p.Text))
                {
                    NoticeInvalidEmail = "Invalid email";
                }
                else
                {
                    NoticeInvalidEmail = "";
                }
            });

            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                RegisterModel model = new RegisterModel();
                CurrentPassword = p.Password;

                if (p.Password.Length > 0)
                {
                    ChangePasswordError = "";
                }    

                if (!model.IsVietKey(p.Password))
                {
                    SpecialCharCurrentPassword = "Password contains vietkey character";
                }
                else
                {
                    SpecialCharCurrentPassword = "";
                }
            });

            NewPasswordChangedCommand = new RelayCommand<PasswordBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                RegisterModel model = new RegisterModel();
                NewPassword = p.Password;

                if (p.Password.Length > 0)
                {
                    ChangePasswordError = "";
                }

                if (!model.IsVietKey(p.Password))
                {
                    SpecialCharNewPassword = "Password contains vietkey character";
                }
                else
                {
                    SpecialCharNewPassword = "";
                }
            });

            ConfirmPasswordChangedCommand = new RelayCommand<PasswordBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                RegisterModel model = new RegisterModel();
                ConfirmPassword = p.Password;

                if (p.Password.Length > 0)
                {
                    ChangePasswordError = "";
                }

                if (!model.IsVietKey(p.Password))
                {
                    SpecialCharConfirmPassword = "Password contains vietkey character";
                }
                else
                {
                    SpecialCharConfirmPassword = "";
                }
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
