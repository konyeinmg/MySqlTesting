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
using MySql.Data.MySqlClient;
namespace mysqltesting
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void btninsert(object sender, RoutedEventArgs e)
        {
            string path = "server=localhost;uid=root;pwd=root;database=sale";
            MySqlConnection con = new MySqlConnection(path);
            con.Open();
            string name = textBoxName.Text;
            string roll = textBoxroll.Text;
            string email = textBoxemail.Text;
            string phone = textBoxphone.Text;
            MySqlCommand cmd = new MySqlCommand("insert into studentInfo(name,rollno,email,phone) values (" + name + "," + roll + "," + email + "," + phone + ")", con);
            int result = cmd.ExecuteNonQuery();
            if(result > 0)
            {
                MessageBox.Show("Ok");
            }
            con.Close();
        }
    }
}
