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
    /// Interaction logic for ResgisterAdditional.xaml
    /// </summary>
    public partial class ResgisterAdditional : Page
    {
        public User theUser;
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader da;
        SqlDataAdapter dr;

        public ResgisterAdditional( User user)
        {
            InitializeComponent();
            theUser = user;
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= [DataDirectoty]\Database1.mdf"";Integrated Security=True");
            cn.Open();

            DateTime StartDate = (DateTime)StartDatePicker.SelectedDate;
            int theDura = Convert.ToInt32(txtDuration.Text);

            theUser.StartDate = StartDate;
            theUser.Duration = theDura;

            SaveInfo(theUser);
            
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            Application.Current.Windows[1].Close();
        }
        protected void SaveInfo(User theUser)
        {
            string Query = "INSERT INTO USERS" +
                "(FirstName, LastName, Email, Password, Start_Date, Duration)" +
                "VALUES (@Fname, @Lname, @Mail, @Pass, @Dat, @Dur)";
            SqlCommand CMD = new SqlCommand(Query, cn);
            CMD.Parameters.AddWithValue("@Fname", theUser.FirstName);
            CMD.Parameters.AddWithValue("@Lname", theUser.Lastname);
            CMD.Parameters.AddWithValue("@Mail", theUser.Email);
            CMD.Parameters.AddWithValue("@Pass", theUser.Password);
            CMD.Parameters.AddWithValue("@Dat", theUser.StartDate);
            CMD.Parameters.AddWithValue("@Dur", theUser.Duration);
            CMD.ExecuteNonQuery();

        }
    }
}
