using HotelManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.MVVM.Model;
using System.Windows.Input;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace HotelManagement.MVVM.ViewModel
{
    class LoginViewModel : ObservableObject
    {
        //tên tài khoản
        private string _username;
        public string Username { get { return _username; } set { _username = value; OnPropertyChanged(); } }

        //mật khẩu
        private string _password;
        public string Password { get { return _password; } set { _password = value; OnPropertyChanged(); } }

        //invalid username and password
        private string _invalidUsenamePassword;
        public string InvalidUsernamePassword 
        { 
            get 
            { 
                return _invalidUsenamePassword; 
            } 
            set 
            { 
                _invalidUsenamePassword = value; 
                OnPropertyChanged(); 
            }
        }

        public ICommand PasswordChangedCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public LoginViewModel()
        {
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                Password = p.Password;
            });

            LoginCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                    return false;
                return true;
            }, (p) =>
            {
                Login(p);
            });

            RegisterCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                Register(p);
            });
        }

        void Login(Window p)
        {
            if (p == null)
                return;

            LoginModel model = new LoginModel();
            if (model.LoginWithUsernameAndPassword(Username, Password))
            {
                //GetStatusAccount(Username) == 1 => Active
                //GetStatusAccount(Username) != 1 => Block
                if (model.GetStatusAccount(Username) == 1)
                {
                    p.Hide();
                    MainWindow wd = new MainWindow();
                    wd.DataContext = new MainViewModel(model.GetIdAccount(Username));
                    wd.Show();
                    p.Close();
                }
                else
                {
                    InvalidUsernamePassword = "Account has been locked!";
                }    
            }
            else
            {
                InvalidUsernamePassword = "Invalid username or password";
            }    
        }

        void Register(Window p)
        {
            if (p == null)
                return;

            p.Hide();
            (new RegisterWindow()).Show();
            p.Close();
        }
    }
}
