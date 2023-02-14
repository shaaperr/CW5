using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
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

namespace CW_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\CW6.accdb");
        }

        private void See_Assets_Click(object sender, RoutedEventArgs e)
        {
            string query = "select* from Assets";

            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            
            while (read.Read())
            {
                for(int i = 0; i < read.FieldCount; i++)
                {
                    data += read[i].ToString() + " ";
                }
                
                data += "\n";
            }
            tbox.Text = data;
            cn.Close();
        }

        private void employees_Click(object sender, RoutedEventArgs e)
        {
            string query = "select* from Employees";

            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";

            while (read.Read())
            {
                for (int i = 0; i < read.FieldCount; i++)
                {
                    data += read[i].ToString() + " ";
                }

                data += "\n";
            }
            tbox.Text = data;
            cn.Close();
        }

        private void tbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
