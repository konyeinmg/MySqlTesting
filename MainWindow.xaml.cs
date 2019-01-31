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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string name = textBoxName.Text;
            string password = passwordBox.Password;
            string path = "server=localhost;uid=root;pwd=root;database=student";

            MySqlConnection con = new MySqlConnection(path);

            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand("select * from admin where name='" + name + "' and password='"+password+"'", con);
                MySqlDataReader data = cmd.ExecuteReader();

                if (data.Read())
                {
                    MessageBox.Show("Login is corrrectly");
                    this.Hide();
                    new Window1().Show();
                }
                else MessageBox.Show("Invalid Login");

            }catch(Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
