using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Runtime.Remoting;
using pserver;
using System.Diagnostics;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels;
using MySql.Data.MySqlClient;
using System.Data;
public partial class _Default : System.Web.UI.Page
{

    string IPAdd, filename, newname;
     void Page_Load(object sender, EventArgs e)
    {
        if (Session["First"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        HttpChannel channel = new HttpChannel();
       // ChannelServices.RegisterChannel(channel);
        
         //string name1 = (string)(Session["First"]);
        try
        {
            string name1 = (string)(Session["First"]);

            Label13.Text = name1;
       
        Label1.Text = " ";
        // To find IP address of a machine behind LAN you can use this code
        string strHostName = Dns.GetHostName();
        IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);

        


        //Find IP Address Behind Proxy Or Client Machine In ASP.NET
        IPAdd = string.Empty;
        IPAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (string.IsNullOrEmpty(IPAdd))
        {
            IPAdd = Request.ServerVariables["REMOTE_ADDR"];
            //Label4.Text = IPAdd;
        }
         
         //literal
        string mar = "<MARQUEE><strong>"+name1 + " IP is <font color='red'>" + IPAdd + "</Font>. It will be used as your ID</strong></MARQUEE>";
        Literal1.Text = mar;

        string mar2 = "<MARQUEE scrollamount='2'><strong>" + name1 + "  IP is <font color='red'>" + IPAdd + "</Font>. It will be used as your ID</MARQUEE></strong>";
        Literal2.Text = mar2;

        string mar3 = "<MARQUEE direction='right'><strong>" + name1 + " IP is <font color='red'>" + IPAdd + "</Font>. It will be used as your ID</MARQUEE></strong>";
        Literal3.Text = mar3;

        string mar4 = "<MARQUEE direction='right' scrollamount='2'><strong>" + name1 + " IP is <font color='red'>" + IPAdd + "</Font>. It will be used as your ID</MARQUEE></strong>";
        Literal4.Text = mar4;
        }
        catch (Exception ex)
        {
        }
    }
   
    protected void Button1_Click1(object sender, EventArgs e)
    {
        string name1 = (string)(Session["First"]);

        if (FileUpload1.HasFile)
        {
            Label1.Text = ("");
            try
            {

                if (FileUpload1.PostedFile.ContentLength < 1512000)
                {
                    string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);


                    filename = Path.GetFileName(FileUpload1.FileName);
                    FileUpload1.SaveAs(Server.MapPath("~/upload/") + name1 + "--" + filename);
                    newname = filename;
                    Label1.Text = FileUpload1.FileName + " sent to Print Server";
                    //add to DB
                    
                    string MyConString = "SERVER=skyynet.cloudapp.net;" + "DATABASE=print;" + "UID=jon;" + "PASSWORD=jon;";
                    MySqlConnection con = new MySqlConnection(MyConString);
                    //MySqlConnection con1 = new MySqlConnection(MyConString);
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO file(name, ip,username) VALUES('" + newname + "', '" + IPAdd + "','"+name1+"')");
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO file2(name, ip,username) VALUES('" + newname + "', '" + IPAdd + "', '"+name1+"')");
                    cmd.Connection = con;
                    cmd1.Connection = con;
                    con.Open();
                    //con1.Open();
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    con.Close();

                    //show in grid
                    string sql = "Select * from file where username='" + name1 + "'";
                    string MyConString1 = "SERVER=skyynet.cloudapp.net;" + "DATABASE=print;" + "UID=jon;" + "PASSWORD=jon;";
                    MySqlConnection connection = new MySqlConnection(MyConString1);
                    MySqlCommand fill = new MySqlCommand(sql, connection);
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(fill);
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    connection.Close();
                   
                    //show in 2nd grid
                    string sql1 = "Select name as 'Queue', username from file";
                    string MyConString2 = "SERVER=skyynet.cloudapp.net;" + "DATABASE=print;" + "UID=jon;" + "PASSWORD=jon;";
                    MySqlConnection connection1 = new MySqlConnection(MyConString2);
                    MySqlCommand fill1 = new MySqlCommand(sql1, connection1);
                    DataTable dt1 = new DataTable();
                    MySqlDataAdapter da1 = new MySqlDataAdapter(fill1);
                    da1.Fill(dt1);
                    GridView2.DataSource = dt1;
                    GridView2.DataBind();
                    connection.Close();



                    
                }// ist if
                else
                    Label1.Text = "File maximum size over Kb";

            }
            catch (Exception exc)
            {
                Label1.Text = "The file could not be uploaded. The following error occured: " + exc.Message;
            }
        }
        else  //check file
        {
            Label1.Text = "Please Choose a File";
        }
        try
        {
            //send to server
            IMyRemoteObject obj = (IMyRemoteObject)Activator.GetObject(
         typeof(IMyRemoteObject),
         "http://localhost:1234/MyRemoteObject.soap");

            string new1 = IPAdd;
            obj.Cvalue(new1, filename);
        }
        catch (Exception)
        {
            string alt = "PrintServer is not Running";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + alt + "');", true);
            Label1.Text = "Check PrintServer is Running";
        }

        


    }//button

   

    

    protected void Button2_Click(object sender, EventArgs e)
    {
        string name1 = (string)(Session["First"]);
        string sql = "Select * from file where username='"+name1+"'";
        string MyConString = "SERVER=skyynet.cloudapp.net;" + "DATABASE=print;" + "UID=jon;" + "PASSWORD=jon;";
        MySqlConnection connection = new MySqlConnection(MyConString);
        MySqlCommand fill = new MySqlCommand(sql, connection);
        DataTable dt = new DataTable();
        MySqlDataAdapter da = new MySqlDataAdapter(fill);
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        connection.Close();

        //show in 2nd grid
        string sql1 = "Select name as 'Queue',username from file";
        string MyConString2 = "SERVER=skyynet.cloudapp.net;" + "DATABASE=print;" + "UID=jon;" + "PASSWORD=jon;";
        MySqlConnection connection1 = new MySqlConnection(MyConString2);
        MySqlCommand fill1 = new MySqlCommand(sql1, connection1);
        DataTable dt1 = new DataTable();
        MySqlDataAdapter da1 = new MySqlDataAdapter(fill1);
        da1.Fill(dt1);
        GridView2.DataSource = dt1;
        GridView2.DataBind();
        connection.Close();
    }

  


    protected void Button3_Click(object sender, EventArgs e)
    {
        string name1 = (string)(Session["First"]);
        string MyConString = "SERVER=skyynet.cloudapp.net;" + "DATABASE=print;" + "UID=jon;" + "PASSWORD=jon;";
        MySqlConnection con = new MySqlConnection(MyConString);
        MySqlCommand cmd = new MySqlCommand("DELETE FROM file where username='"+name1+"'");
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        string sql = "Select * from file where username='" + name1 + "'";
        string MyConString1 = "SERVER=skyynet.cloudapp.net;" + "DATABASE=print;" + "UID=jon;" + "PASSWORD=jon;";
        MySqlConnection connection = new MySqlConnection(MyConString1);
        MySqlCommand fill = new MySqlCommand(sql, connection);
        DataTable dt = new DataTable();
        MySqlDataAdapter da = new MySqlDataAdapter(fill);
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        connection.Close();

        //show in 2nd grid
        string sql1 = "Select name as 'Queue',username from file";
        string MyConString2 = "SERVER=skyynet.cloudapp.net;" + "DATABASE=print;" + "UID=jon;" + "PASSWORD=jon;";
        MySqlConnection connection1 = new MySqlConnection(MyConString2);
        MySqlCommand fill1 = new MySqlCommand(sql1, connection1);
        DataTable dt1 = new DataTable();
        MySqlDataAdapter da1 = new MySqlDataAdapter(fill1);
        da1.Fill(dt1);
        GridView2.DataSource = dt1;
        GridView2.DataBind();
        connection.Close();

        //
        IMyRemoteObject obj = (IMyRemoteObject)Activator.GetObject(
      typeof(IMyRemoteObject),
      "http://localhost:1234/MyRemoteObject.soap");

        string new1 = IPAdd;
        obj.ckill(IPAdd);
       
    }




    protected void Button4_Click(object sender, EventArgs e)
    {
       Response.Write("<script>window.open('Default.aspx','_blank');</script>");
    }

   
}