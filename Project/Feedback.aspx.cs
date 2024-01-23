using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Feedback : System.Web.UI.Page
{    
    SqlConnection con = new SqlConnection(@"Data Source=HDAVE;Initial Catalog=Phishing;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Text = (string)Session["id"];
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        string s = "insert into feed values('" + Label2.Text + "','" + TextBox1.Text + "')";
        SqlCommand cmd = new SqlCommand(s, con);
        cmd.ExecuteNonQuery();
        TextBox1.Text = "";
        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Thank u!!!Ur feedback is submitted')", true);
    }
}