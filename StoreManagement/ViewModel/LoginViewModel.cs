using StoreManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StoreManagement.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }
        private string _Username;
        // TextBox of user name is binded to this UserName prop
        public string UserName { get => _Username; set { _Username = value; OnPropertyChanged(); } }
        // PasswordBox of pass word is binded to this Password prop
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        public ICommand PasswordChangedCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public LoginViewModel()
        {
            // initilize UserName and Password so errors does not occur
            UserName = Password = "";
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            ExitCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });

        }

        void Login(Window p)
        {
            if (p == null) return;

            // check authentication -> use DataProvider
            var passEncode = MD5Hash(Base64Encode(Password));
            var accCount = DataProvider.Ins.DB.Users.Where(x => x.UserName == UserName && x.Password == passEncode).Count();

            if (accCount >0)
            {
                IsLogin = true;
                p.Close();

            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Wrong username or password");
            }

        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
