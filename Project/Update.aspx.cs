using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Update : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=admin-pc\sqlexpress;Initial Catalog=web;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        Label4.Text = (string)Session["iid"];
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Label4.Text = (string)Session["iid"];
            con.Open();
            string s = "update admin set pwd='" + TextBox2.Text + "' where id='" + Label4.Text + "' and pwd='" + TextBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();

            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Password Updated Successfully!!!')", true);
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('No match found!!!')", true);
        }
    }
}