using HotelManagement.Core;
using HotelManagement.MVVM.Model;

namespace HotelManagement.MVVM.ViewModel
{
    /// <summary>
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public class ProfileViewModel : ObservableObject
    {
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
        private string _birthday;
        public string Birthday { get { return _birthday; } set { _birthday = value; OnPropertyChanged(); } }

        //Email của người dùng
        private string _email;
        public string Email { get { return _email; } set { _email = value; OnPropertyChanged(); } }
        
        //Chức vụ (Quyền hạn) của người dùng
        private string _position;
        public string Position { get { return _position; } set { _position = value; OnPropertyChanged(); } }

        public ProfileViewModel()
        {

        }
    }
}
