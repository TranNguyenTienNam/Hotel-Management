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

        private string _firstName;
        public string FirstName { get { return _firstName; } set { _firstName = value; OnPropertyChanged(); } }
        
        private string _lastName;
        public string LastName { get { return _lastName; } set { _lastName = value; OnPropertyChanged(); } }
        
        private string _email;
        public string Email { get { return _email; } set { _email = value; OnPropertyChanged(); } }

        private string _username;
        public string Username { get { return _username; } set { _username = value; OnPropertyChanged("username"); } }

        private string _password;
        public string Password { get { return _password; } set { _password = value; OnPropertyChanged(); } }

        private string _confirmPassword;
        public string ConfirmPassword { get { return _confirmPassword; } set { _confirmPassword = value; OnPropertyChanged(); } }
        
        //xác nhận mật khẩu
        private string _registerErrorMessage;
        public string RegisterErrorMessage { get { return _registerErrorMessage; } set { _registerErrorMessage = value; OnPropertyChanged(); } }

        //label notice special char Username
        private string _specialCharUsername;
        public string SpecialCharUsername { get { return _specialCharUsername; } set { _specialCharUsername = value; OnPropertyChanged(); } }

        //label notice special char Password
        private string _specialCharPassword;
        public string SpecialCharPassword { get { return _specialCharPassword; } set { _specialCharPassword = value; OnPropertyChanged(); } }

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

                if (p.Password.Length > 0)
                {
                    RegisterErrorMessage = "";
                }
                if (!model.IsVietKey(p.Password))
                {
                    SpecialCharPassword = "Password contains vietkey characters";
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

                if (p.Password.Length > 0)
                {
                    RegisterErrorMessage = "";
                }
                if (!model.IsVietKey(p.Password))
                {
                    SpecialCharConfirmPassword = "Confirm password contains vietkey characters";
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
                if (p.Text.Length > 0)
                {
                    RegisterErrorMessage = "";
                }
                if (!model.IsVietKey(p.Text) || !model.IsSpecialChar(p.Text))
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
                Cancel(p);
            });

            FinishCommand = new RelayCommand<object[]>((p) =>
            {
                if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword)
                    || string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(Email))
                    return false;
                if (SpecialCharConfirmPassword != "" || SpecialCharPassword != "" || SpecialCharUsername != "" || InvalidMail != "")
                    return false;
                return true;
            }, (p) =>
            {
                Register(p);
            });
        }

        /// <summary>
        /// ChangePasswordCommand have 4 parameter (object[])
        /// 0 => <include file='RegisterWindow.xaml' path='[@ElementName="registerWindow"]'/>
        /// 1 => <include file='RegisterWindow.xaml' path='[@ElementName="txtUsername"]'/>
        /// 2 => <include file='RegisterWindow.xaml' path='[@ElementName="txtPassword"]'/>
        /// 3 => <include file='RegisterWindow.xaml' path='[@ElementName="txtConfirmPassword"]'/>
        /// </summary>
        void Register(object[] p)
        {
            if (p == null)
                return;
            //Get array parameter
            var values = (object[])p;
            Window registerWindow = values[0] as Window;    
            TextBox txtUsername = values[1] as TextBox;
            PasswordBox txtPassword = values[2] as PasswordBox;
            PasswordBox txtConfirmPassword = values[3] as PasswordBox;

            if (model.CheckExistUsername(Username))
            {
                RegisterErrorMessage = "This username has already existed";
                txtUsername.Text = "";
                return;
            }    
            else
            {
                if (Password == ConfirmPassword)
                {
                    int isID = model.RegisterWithUsernameAndPassword(Username, Password);
                    if (isID != -1)
                    {
                        if (model.InsertInfoUser(isID, FirstName, LastName, Email))
                        {
                            MessageBox.Show("Registration success", "Notice");
                            registerWindow.Hide();
                            (new LoginWindow()).Show();
                            registerWindow.Close();
                        }    
                    }    
                }
                else
                {
                    RegisterErrorMessage = "Password and confirm password are different";
                    txtPassword.Password = "";
                    txtConfirmPassword.Password = "";
                    return;
                }    
            }
        }

        void Cancel(Window p)
        {
            if (p == null)
                return;

            p.Hide();
            (new LoginWindow()).Show();
            p.Close();
        }
    }
}
