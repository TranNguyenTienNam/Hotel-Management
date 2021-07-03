using HotelManagement.Core;
using HotelManagement.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HotelManagement.MVVM.ViewModel
{
    class RegisterViewModel : ObservableObject
    {
        //Họ của người dùng
        private string _ho;
        public string Ho { get { return _ho; } set { _ho = value; OnPropertyChanged(); } }
        
        //Tên của người dùng
        private string _ten;
        public string Ten { get { return _ten; } set { _ten = value; OnPropertyChanged(); } }
        
        //Tên của người dùng
        private string _email;
        public string Email { get { return _email; } set { _email = value; OnPropertyChanged(); } }

        //tên tài khoản
        private string _username;
        public string Username { get { return _username; } set { _username = value; OnPropertyChanged(); } }

        //mật khẩu
        private string _password;
        public string Password { get { return _password; } set { _password = value; OnPropertyChanged(); } }

        //xác nhận mật khẩu
        private string _confirmPassword;
        public string ConfirmPassword { get { return _confirmPassword; } set { _confirmPassword = value; OnPropertyChanged(); } }


        public ICommand PasswordChangedCommand { get; set; }
        public ICommand ConfirmPasswordChangedCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand FinishCommand { get; set; }

        public RegisterViewModel()
        {
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                Password = p.Password;
            });

            ConfirmPasswordChangedCommand = new RelayCommand<PasswordBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                ConfirmPassword = p.Password;
            });

            CancelCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                p.Hide();
                (new LoginWindow()).Show();
                p.Close();
            });

            FinishCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                Register(p);
            });
        }

        void Register(Window p)
        {
            RegisterModel model = new RegisterModel();

            if (model.CheckExistUsername(Username))
            {
                MessageBox.Show("This username has already existed");
            }    
            else
            {
                if (Password == ConfirmPassword)
                {
                    int isID = model.RegisterWithUsernameAndPassword(Username, Password);
                    if (isID != -1)
                    {
                        if (model.InsertInfoUser(isID, Ho, Ten, Email))
                        {

                        }    
                    }    
                }    
            }
        }
    }
}
