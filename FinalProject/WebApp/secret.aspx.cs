using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

public partial class secret : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string MyConString = "SERVER=skyynet.cloudapp.net;" + "DATABASE=print;" + "UID=jon;" + "PASSWORD=jon;";
        MySqlConnection con = new MySqlConnection(MyConString);
        MySqlCommand cmd = new MySqlCommand("DELETE FROM logs where message=''");
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        

        string sql = "Select * from logs ";
        string MyConString1 = "SERVER=skyynet.cloudapp.net;" + "DATABASE=print;" + "UID=jon;" + "PASSWORD=jon;";
        MySqlConnection connection = new MySqlConnection(MyConString1);
        MySqlCommand fill = new MySqlCommand(sql, connection);
        DataTable dt = new DataTable();
        MySqlDataAdapter da = new MySqlDataAdapter(fill);
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        connection.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("secret.aspx");
    }
}