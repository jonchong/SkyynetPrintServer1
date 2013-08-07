using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting;
using MySql.Data.MySqlClient;
using pserver;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels;
using System.Net;
using System.Web;
using System.Threading;
using System.Diagnostics;


namespace server3
{
    public partial class Form1 : Form
    {
        class MyRemoteObject: MarshalByRefObject, IMyRemoteObject
{
string myvalue;
public MyRemoteObject()
{
Console.WriteLine("PRINT SERVER=>> New Object created");
}
public MyRemoteObject(string startvalue)
{
Console.WriteLine("MyRemoteObject.Constructor: .ctor called with {0}",
startvalue);
myvalue = startvalue;
}
public void SetValue(string newval)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(DateTime.Now.ToString("HH:mm:ss tt")+" SERVER set() ");
    Console.ResetColor();
Console.WriteLine("PAUSE");
myvalue = newval;
}
public void Cvalue(string newval,string jon)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(DateTime.Now.ToString("HH:mm:ss tt") + " CLIENT sent() ");
    Console.ResetColor();
    Console.WriteLine("From = {0}  {1}",
     newval, jon);
    myvalue = newval;
}

public void ckill(string newval)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(DateTime.Now.ToString("HH:mm:ss tt") + " CLIENT set() ");
    Console.ResetColor();
    Console.WriteLine("{0} Killed Their JOBS",newval);
    myvalue = newval;
}

public void erase(string newval)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(DateTime.Now.ToString("HH:mm:ss tt") + " SERVER set() ");
    Console.ResetColor();
    Console.WriteLine("HISTORY ERASED");
    myvalue = newval;
}
public void sdelete(string newval)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(DateTime.Now.ToString("HH:mm:ss tt") + " SERVER set() ");
    Console.ResetColor();
    Console.WriteLine("Deleted job {0}",newval);
    myvalue = newval;
}



public void history(string newval)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(DateTime.Now.ToString("HH:mm:ss tt") + " SERVER set() ");
    Console.ResetColor();
    Console.WriteLine("Requested HISTORY");
    myvalue = newval;
    //mysql part
    string myConnectionString = "SERVER=localhost;" +
                            "DATABASE=print;" +
                            "UID=jon;" +
                            "PASSWORD=jon;";

    MySqlConnection connection = new MySqlConnection(myConnectionString);
    MySqlCommand command = connection.CreateCommand();
    command.CommandText = "SELECT * FROM file2";
    MySqlDataReader Reader;
    connection.Open();
    Reader = command.ExecuteReader();
    Console.ForegroundColor = ConsoleColor.Green;
    while (Reader.Read())
    {
        string row = "";
        for (int i = 0; i < Reader.FieldCount; i++)
            row += Reader.GetValue(i).ToString() + " || ";
        Console.WriteLine(row);
    }
    connection.Close();
    Console.ResetColor();





}

public void resume(string newval)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(DateTime.Now.ToString("HH:mm:ss tt") + " SERVER set() ");
    Console.ResetColor();
    Console.WriteLine("Resume Printing");
    
    myvalue = newval;
}

public void pause(string newval)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(DateTime.Now.ToString("HH:mm:ss tt") + " SERVER set() ");
    Console.ResetColor();
    Console.WriteLine("Retrieve IP.List() for cost");
    Console.WriteLine("{0} per job.", newval);
    myvalue = newval;
    //mysql part
    string myConnectionString = "SERVER=localhost;" +
                            "DATABASE=print;" +
                            "UID=jon;" +
                            "PASSWORD=jon;";

    MySqlConnection connection = new MySqlConnection(myConnectionString);
    MySqlCommand command = connection.CreateCommand();
    command.CommandText = "SELECT ip,COUNT(ip) as 'Jobs Sent to Server' FROM file2 GROUP BY ip";
    MySqlDataReader Reader;
    connection.Open();
    Reader = command.ExecuteReader();
    while (Reader.Read())
    {
        string row = "";
        for (int i = 0; i < Reader.FieldCount; i++)
            row += Reader.GetValue(i).ToString() + ", ";
        Console.WriteLine(row);
    }
    connection.Close();
}

public string GetValue()
{
//Console.WriteLine("MyRemoteObject.getValue(): current {0}",myvalue);
return myvalue;
}
}
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            label6.Visible = false;
            t1.Text = "0";
            label4.Visible = false;
            dataGridView2.Visible = false;
            progressBar1.ForeColor = Color.Cyan;
            progressBar1.Style = ProgressBarStyle.Continuous;
            timer1.Start();
            timer2.Start();
            timer3.Start();
            Console.Write("Loading ");
            /*Console.ForegroundColor = ConsoleColor.Green;
            for (int a = 0; a < 65; a++)
            {

                Console.Write("#");
                System.Threading.Thread.Sleep(50);
            }
            Console.ResetColor();
            */
            String strHostName = string.Empty;
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            //IPAddress[] addr = ipEntry.AddressList;
            //Console.WriteLine("\nSERVER Ready. Listening on: " + addr[3].ToString());
            
            
            Console.WriteLine("\nServerStartup(): Server started..");
            HttpChannel chnl = new HttpChannel(1234);
            ChannelServices.RegisterChannel(chnl);
            RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(MyRemoteObject),
            "MyRemoteObject.soap",
            WellKnownObjectMode.Singleton); 
            
            //
            
           // string myip = addr[3].ToString();
            label1.Text = ("SERVER LISTENING ON :777");
            
           

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            label3.Text = ("Paused");
            timer3.Stop();
            IMyRemoteObject obj = (IMyRemoteObject)Activator.GetObject(typeof(IMyRemoteObject),
                "http://localhost:1234/MyRemoteObject.soap");
            string a = "a";
            obj.SetValue(a);


            
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            dataGridView1.Visible = true;
            string conn = "server=localhost;user=jon;password=jon;database=print;";
            MySqlConnection myconn = new MySqlConnection(conn);
            string sql = "SELECT * FROM file";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, myconn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if ((dt == null)|| (dt.Rows.Count == 0))
            {
                label3.Visible = false;
                dataGridView1.Visible = false;
                label6.Visible = true;
            }
            else
            {
                label6.Visible = false;
                label3.Visible = true;
                dataGridView1.DataSource = dt;
            }
            myconn.Close();
          
           
        }//timer1

       


        private void progressBar1_Click(object sender, System.EventArgs e)
        {

        }

        private void timer2_Tick(object sender, System.EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 5; 
            }
            else
            {
                progressBar1.Value = 0;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer3_Tick(object sender, System.EventArgs e)
        {
            
            string MyConString = "SERVER=localhost;" + "DATABASE=print;" + "UID=jon;" + "PASSWORD=jon;";
            MySqlConnection con = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("DELETE FROM file limit 1");
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            label3.Text = ("Printing");
            timer3.Start();
            IMyRemoteObject obj = (IMyRemoteObject)Activator.GetObject(typeof(IMyRemoteObject),
               "http://localhost:1234/MyRemoteObject.soap");
            string a = "a";
            obj.resume(a);
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            IMyRemoteObject obj = (IMyRemoteObject)Activator.GetObject(typeof(IMyRemoteObject),
                "http://localhost:1234/MyRemoteObject.soap");
            string a = "a";
            obj.history(a);
            //
            label4.Text = ("HISTORY");
            label4.Visible = true;
            dataGridView2.Visible = true;
            string conn = "server=localhost;user=jon;password=jon;database=print;";
            MySqlConnection myconn = new MySqlConnection(conn);
            string sql = "SELECT * FROM file2";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, myconn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if ((dt == null) || (dt.Rows.Count == 0))
            {
                
                dataGridView2.Visible = false;
            }
            else
            {
                
                dataGridView2.DataSource = dt;
            }
            myconn.Close();
            t1.Text = "0";
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            try
            {   
                decimal money = 0;
                money = decimal.Parse(t1.Text);
                
                dataGridView2.Visible = true;
                dataGridView2.DataSource = null;
                label4.Text = ("COST CALULATOR");
                label4.Visible = true;
                string conn = "server=localhost;user=jon;password=jon;database=print;";
                MySqlConnection myconn = new MySqlConnection(conn);
                string sql = "SELECT username,COUNT(username) as 'Jobs Sent to Server',COUNT(username)*"+money+" as 'Cost in Dollars' FROM file2 GROUP BY username";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, myconn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if ((dt == null) || (dt.Rows.Count == 0))
                {

                    dataGridView2.Visible = false;
                }
                else
                {
                    IMyRemoteObject obj = (IMyRemoteObject)Activator.GetObject(typeof(IMyRemoteObject),
                "http://localhost:1234/MyRemoteObject.soap");
                    string a = money.ToString();
                    obj.pause(a);
                    dataGridView2.DataSource = dt;
                }
                myconn.Close();
                t1.Text = "0";






            }//try
            catch (Exception)
            {
                MessageBox.Show("No Strings");
                t1.Text = "0";
            }
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            //clear
            Form2 f2 = new Form2();
            f2.ShowDialog(); 

        }

       

        private void button7_Click_1(object sender, EventArgs e)
        {
            Process.Start(@"C:\inetpub\wwwroot\pserver\upload\");
        }

       

       

        private void button8_Click_1(object sender, EventArgs e)
        {
            label3.Text = ("Paused");
            timer3.Stop();
            IMyRemoteObject obj = (IMyRemoteObject)Activator.GetObject(typeof(IMyRemoteObject),
                "http://localhost:1234/MyRemoteObject.soap");
            string a = "a";
            obj.SetValue(a);
            Form3 f3 = new Form3();
            f3.ShowDialog();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:8080/meeting/hc.php";

            System.Diagnostics.Process proc = new System.Diagnostics.Process();

            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(url);

            proc.StartInfo = startInfo;

            proc.Start();
        }

        

       
       

        
            
    }
}
