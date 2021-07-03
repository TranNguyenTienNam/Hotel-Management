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
        RegisterModel model;
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
        public string Username { get { return _username; } set { _username = value; OnPropertyChanged("username"); } }

        //mật khẩu
        private string _password;
        public string Password { get { return _password; } set { _password = value; OnPropertyChanged(); } }

        //xác nhận mật khẩu
        private string _confirmPassword;
        public string ConfirmPassword { get { return _confirmPassword; } set { _confirmPassword = value; OnPropertyChanged(); } }

        //label notice special char Username
        private string _specialCharUsername;
        public string SpecialCharUsername { get { return _specialCharUsername; } set { _specialCharUsername = value; OnPropertyChanged(); } }

        //label notice special char Password
        private string _specialCharPassword;
        public string SpecialCharPassword { get { return _specialCharPassword; } set { _specialCharPassword = value; OnPropertyChanged(); } }

        //label notice special char Password
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

        //label notice special char Password
        private string _invalidMail;
        public string InvalidMail { get { return _invalidMail; } set { _invalidMail = value; OnPropertyChanged(); } }

        public ICommand PasswordChangedCommand { get; set; }
        public ICommand ConfirmPasswordChangedCommand { get; set; }
        public ICommand UsernameTextChangedCommand { get; set; }
        public ICommand EmailTextChangedCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand FinishCommand { get; set; }

        public RegisterViewModel()
        {
            model = new RegisterModel();

            SpecialCharUsername = "";
            SpecialCharPassword = "";
            SpecialCharConfirmPassword = "";
            InvalidMail = "";

            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                Password = p.Password;
                if (!model.IsSpecialChar(p.Password))
                {
                    SpecialCharPassword = "Password contains special characters";
                }
                else
                {
                    SpecialCharPassword = "";
                }
            });

            ConfirmPasswordChangedCommand = new RelayCommand<PasswordBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                ConfirmPassword = p.Password;
                if (!model.IsSpecialChar(p.Password))
                {
                    SpecialCharConfirmPassword = "Confirm password contains special characters";
                }
                else
                {
                    SpecialCharConfirmPassword = "";
                }
            });

            UsernameTextChangedCommand = new RelayCommand<TextBox>((p) =>
            {
                return true;
            }, (p) =>
            { 
                if (!model.IsSpecialChar(p.Text))
                {
                    SpecialCharUsername = "Username contains special characters";
                }    
                else
                {
                    SpecialCharUsername = "";
                }
            });

            EmailTextChangedCommand = new RelayCommand<TextBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (!model.IsValidEmail(p.Text))
                {
                    InvalidMail = "Invalid email";
                }
                else
                {
                    InvalidMail = "";
                }
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
                if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword)
                    || string.IsNullOrEmpty(Ho) || string.IsNullOrEmpty(Ten) || string.IsNullOrEmpty(Email))
                    return false;
                if (SpecialCharConfirmPassword != "" || SpecialCharPassword != "" || SpecialCharUsername != "" || InvalidMail != "")
                    return false;
                return true;
            }, (p) =>
            {
                Register(p);
            });
        }

        void Register(Window p)
        {
            if (p == null)
                return;

            if (model.CheckExistUsername(Username))
            {
                MessageBox.Show("This username has already existed");
                return;
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
                            MessageBox.Show("Registration success");
                            p.Hide();
                            (new LoginWindow()).Show();
                            p.Close();
                        }    
                    }    
                }
                else
                {
                    MessageBox.Show("Password and confirm password are different");
                    return;
                }    
            }
        }
    }
}
