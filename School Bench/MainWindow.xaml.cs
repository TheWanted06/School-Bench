using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace School_Bench
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WelcomeFrame.Content = new LoginPage();
            PageName.Text = "Login";
        }
        

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        public string HashPassword(string password)
        {
            SHA256 Hash = SHA256.Create();
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var hashedPassword = Hash.ComputeHash(passwordBytes);
            return Convert.ToHexString(hashedPassword);
        }
    }
}
