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
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels;
namespace server3

{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

       


        private void Form3_Load(object sender, EventArgs e)
        {
            //start remoting 
           

            string conn = "server=localhost;user=jon;password=jon;database=print;";
            MySqlConnection myconn = new MySqlConnection(conn);
            string sql = "SELECT name,ip,username FROM file";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, myconn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button8_Click(object sender, EventArgs e)
        {

            string job = t1.Text.ToString();
            string MyConString = "SERVER=localhost;" + "DATABASE=print;" + "UID=jon;" + "PASSWORD=jon;";
            MySqlConnection con = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("DELETE FROM file where name='"+job+"'");
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            this.Close();

            IMyRemoteObject obj = (IMyRemoteObject)Activator.GetObject(typeof(IMyRemoteObject),
                "http://localhost:1234/MyRemoteObject.soap");
            string a = "a";
            obj.sdelete(job);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string job = t2.Text.ToString();
            string MyConString = "SERVER=localhost;" + "DATABASE=print;" + "UID=jon;" + "PASSWORD=jon;";
            MySqlConnection con = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("DELETE FROM file where ip='" + job + "'");
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string conn = "server=localhost;user=jon;password=jon;database=print;";
            MySqlConnection myconn = new MySqlConnection(conn);
            string sql = "SELECT name,ip,username FROM file";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, myconn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string job = t3.Text.ToString();
            string MyConString = "SERVER=localhost;" + "DATABASE=print;" + "UID=jon;" + "PASSWORD=jon;";
            MySqlConnection con = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("DELETE FROM file where username='" + job + "'");
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            this.Close();
        }

        
    }
}
