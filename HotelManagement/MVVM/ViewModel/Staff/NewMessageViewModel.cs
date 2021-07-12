using HotelManagement.Core;
using HotelManagement.MVVM.View.Staff;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelManagement.MVVM.ViewModel.Staff
{
    class NewMessageViewModel : ObservableObject
    {
        private string address;
        public string Address { get { return address; } set { address = value; OnPropertyChanged(); } }
        
        private string subject;
        public string Subject { get { return subject; } set { subject = value; OnPropertyChanged(); } }

        private string content;
        public string Content { get { return content; } set { content = value; OnPropertyChanged(); } }

        private ObservableCollection<AttachedFileViewModel> attachedFiles;
        public ObservableCollection<AttachedFileViewModel> AttachedFiles { get { return attachedFiles; } set { attachedFiles = value; } }

        public ICommand ClickExitCommand { get; set; }
        public ICommand SendCommand { get; set; }
        public ICommand AttachCommand { get; set; }
        public ICommand DiscardCommand { get; set; }
        public NewMessageViewModel(string Email)    
        {
            Address = Email;
            AttachedFiles = new ObservableCollection<AttachedFileViewModel>();

            ClickExitCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                p.Close();
            });

            SendCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (checkNullOrEmpty(Address))
                {
                    MessageBox.Show("Please specify at least one recipient.", "Error");
                }
                else
                {
                    if (checkNullOrEmpty(Subject) && checkNullOrEmpty(Content) && AttachedFiles.Count == 0)
                    {
                        MessageBox.Show("Don't leave text in the body blank", "Error");
                    }
                    else
                    {
                        sendEmail();
                        p.Close();
                    }
                }
            });

            AttachCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                attachFile();
            });

            DiscardCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                discardMail();
            });

            EventSystem.Subscribe<Message>(removeAttachedFile);
        }

        void sendEmail()
        {
            MailMessage mail = new MailMessage(); //
            mail.IsBodyHtml = true;
            
            mail.From = new MailAddress("nbtm072021@gmail.com");
            mail.To.Add(Address);
            mail.Subject = Subject;
            mail.Body = Content;
            SmtpClient client = new SmtpClient("smtp.gmail.com"); 
            client.Host = "smtp.gmail.com";
            client.UseDefaultCredentials = false;
            client.Port = 587; 
            client.Credentials = new System.Net.NetworkCredential("nbtm072021@gmail.com", "loimeothitham");

            foreach (AttachedFileViewModel files in AttachedFiles)
            {
                if (files != null)
                {
                    mail.Attachments.Add(new Attachment(files.FilePath));
                }
            }

            client.EnableSsl = true; 
            client.Send(mail);
            MessageBox.Show("Đã gửi tin nhắn thành công!", "Thành Công", MessageBoxButton.OK);
        }

        void attachFile()
        {
            string fileName = ""; 
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Multiselect = true;
            myDialog.InitialDirectory = "";
            myDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            myDialog.FilterIndex = 2;
            myDialog.RestoreDirectory = true;

            if (myDialog.ShowDialog() == true)
            {
                foreach (string file in myDialog.FileNames)
                {
                    fileName = Path.GetFileName(file);
                    var attachedFile = new AttachedFileViewModel()
                    {
                        FileName = fileName,
                        FilePath = file,
                    };
                    AttachedFiles.Add(attachedFile);
                }
            }
        }

        void discardMail()
        {
            Subject = "";
            Content = "";
            AttachedFiles.Clear();
        }

        public void removeAttachedFile(Message message)
        {
            if (message.message.Contains("RemoveFile|")) 
            {
                string[] vs = message.message.Split('|');
                AttachedFiles.Remove(AttachedFiles.Where(X => X.FileName == vs[1]).Single());
            }
        }

        bool checkNullOrEmpty(string str)
        {
            return (str == "" || str == null);
        }
    }
}