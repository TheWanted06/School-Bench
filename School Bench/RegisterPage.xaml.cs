using School_Bench.Classes;
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
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Loginbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Content = null;
            MainWindow mainWindow = new MainWindow();
            mainWindow.PageName.Text = "Login";
            mainWindow.WelcomeFrame.Content = new LoginPage();
            mainWindow.Show();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lab_services_student\source\repos\School Bench\School Bench\Database1.mdf"";Integrated Security=True");
            cn.Open();

            string Fname = txtFirstName.Text;
            string Lname = txtLastName.Text;
            string Email = txtEmail.Text;
            string Password1 = txtPass.Password.ToString();
            string Password2 = txtConPass.Password.ToString();

            if(Password1 != Password2)
            {
                txtError.Text = "Password not Matching";
            }
            else
            {
                txtError.Text = "";
                //chech if email is already in use
                if (FindEmail(Email))
                {
                    //hashing password 
                    var HashedPW = Encrypt.HashPassword(Password1);

                    User user = new User();
                    user.FirstName = Fname;
                    user.Lastname = Lname;
                    user.Email = Email;
                    user.Password = HashedPW;


                    this.Content = null;
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.PageName.Text = "Additional";
                    mainWindow.WelcomeFrame.Content = new ResgisterAdditional(user);
                    mainWindow.Show();

                }
                
            }
            cn.Close();
        }
        public bool FindEmail(string email)
        {
            string QUERY = $"SELECT UserId FROM USERS WHERE Email ={email}";
            cmd = new SqlCommand(QUERY, cn);

            da = new SqlDataAdapter(cmd);
            
            int UserExist = cmd.ExecuteNonQuery();
            if (UserExist>0) 
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
