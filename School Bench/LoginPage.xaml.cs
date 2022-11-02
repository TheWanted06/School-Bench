using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader da;
        SqlDataAdapter dr;
        public LoginPage()
        {
            
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //check credentials
            string theEmail = txtEmail.Text;
            string thepass = txtPassWord.Password.ToString();

            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= [DataDirectoty]\Database1.mdf"";Integrated Security=True");
            cn.Open();
            


        }

        private void SignUpbt_Click(object sender, RoutedEventArgs e)
        {
            this.Content = null;
            MainWindow mainWindow = new MainWindow();
            mainWindow.PageName.Text = "Register";
            mainWindow.WelcomeFrame.Content = new RegisterPage();
            mainWindow.Show();
        }
        public bool GetUser(string email)
        {
            string QUERY = $"SELECT Email FROM USERS WHERE Email = {email}";
            SqlCommand CMD = new SqlCommand(QUERY, cn);
            CMD.ExecuteNonQuery();
            if (CMD.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
