using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using pserver;
namespace server3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pass = t1.Text.ToString();

            if (pass == "admin")
            {
                string MyConString = "SERVER=localhost;" + "DATABASE=print;" + "UID=jon;" + "PASSWORD=jon;";
                MySqlConnection con = new MySqlConnection(MyConString);
                MySqlCommand cmd = new MySqlCommand("TRUNCATE table file2");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                this.Close();
                MessageBox.Show("History Deleted");
                
                IMyRemoteObject obj = (IMyRemoteObject)Activator.GetObject(typeof(IMyRemoteObject),
                "http://localhost:1234/MyRemoteObject.soap");
                string a = "a";
                obj.erase(a);
            }

            else
            {
                MessageBox.Show("Access Denied");
                this.Close();
            }
            
            
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
