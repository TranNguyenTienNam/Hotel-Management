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
                return true;
            }, (p) =>
            {
                login(p);
            });

            RegisterCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                register(p);
            });
        }

        void login(Window p)
        {
            if (p == null)
                return;

            LoginModel model = new LoginModel();
            if (model.LoginWithUsernameAndPassword(Username, Password))
            {
                if (model.GetStatusAccount(Username, Password) == 1)
                {
                    p.Hide();
                    new MainWindow().Show();
                    p.Close();
                }
                else
                {
                    MessageBox.Show("Account has been locked!");
                }    
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }    
        }

        void register(Window p)
        {
            if (p == null)
                return;

            p.Hide();
            (new RegisterWindow()).Show();
            p.Close();
        }
    }
}
