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

namespace server3
{
    
    public partial class Form4 : Form
    {
        int alpha = 0;
        public Form4()
        {
            InitializeComponent();
        }


        public void stop()
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();
            timer5.Stop();
            timer6.Stop();

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            timer6.Start();
            timer5.Start();
            timer4.Start();
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (alpha++ < 155)
            {
                Image image = pictureBox1.Image;
                using (Graphics g = Graphics.FromImage(image))
                {
                    Pen pen = new Pen(Color.FromArgb(alpha, 255, 255, 255), image.Width);
                    g.DrawLine(pen, -1, -1, image.Width, image.Height);
                    g.Save();
                }
                pictureBox1.Image = image;
            }
            else
            {   
                timer1.Stop();
               
            }
        }//timer

        

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer3.Start();
            timer2.Stop();
            label1.Visible = true;
            ////pictureBox1.Image = server3.Properties.Resources.c1;
           
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            progressBar1.Visible = true;

            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 5;
            }
            else
            {
                progressBar1.Value = 0;
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {   
            timer1.Start();
            timer3.Stop();
            label1.Visible = false;
            progressBar1.Visible = false;
            label2.Visible = false;

        }

        private void timer5_Tick(object sender, EventArgs e)
        {

            stop();
            var form1 = new Form1();

            form1.Show();
            this.Hide();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            label2.Visible = true;
            try
            {
                string conn = "server=localhost;user=jon;password=jon;database=print;";
                MySqlConnection myconn = new MySqlConnection(conn);
                string sql = "SELECT * FROM file";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, myconn);
                DataTable dt = new DataTable();
                da.Fill(dt);
            }//try
            catch (Exception)
            {
                stop();
                MessageBox.Show("Check MySQL DB is Running");
                this.Close();
            }
        }//timer
        

    }
}
