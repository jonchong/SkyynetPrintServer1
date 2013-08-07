using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {//Display JavaScript Variable in Textbox Control...
        TextBox1.Text = "";
            }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox1.Text = Hidden1.Value;
        if (TextBox1.Text == "")
        {
            Response.Redirect("Default.aspx");
        }
        string name = Hidden1.Value;
        Session.Add("First", name);
        Response.Redirect("http://skyynet.cloudapp.net:8080/jump.php?userid=" + name);
        
    }
}