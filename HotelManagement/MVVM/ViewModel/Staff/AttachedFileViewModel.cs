using HotelManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelManagement.MVVM.ViewModel.Staff
{
    class AttachedFileViewModel : ObservableObject
    {
        private string fileName;
        public string FileName { get { return fileName; } set { fileName = value; } }

        private string filePath;
        public string FilePath { get { return filePath; } set { filePath = value; } }

        public ICommand RemoveCommand { get; set; }
        public AttachedFileViewModel()
        {
            RemoveCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                removeFile();
            });
        }

        void removeFile()
        {
            EventSystem.Publish<Message>(new Message { message = "RemoveFile|" + FileName });
        }
    }
}