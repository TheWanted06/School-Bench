using System;
using System.Collections.Generic;
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
        public ResgisterAdditional()
        {
            InitializeComponent();
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }
    }
}
