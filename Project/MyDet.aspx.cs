using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class MyDet : System.Web.UI.Page
{    
    SqlConnection con = new SqlConnection(@"Data Source=HDAVE;Initial Catalog=Phishing;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        string s = "select * from reg where un='" + Session["id"] + "' and pass='" + Session["pass"] + "'";
        SqlDataAdapter sda = new SqlDataAdapter(s, con);
        DataSet ds = new DataSet();
        sda.Fill(ds);

        if (ds.Tables[0].Rows.Count != 0)
        {
            Label2.Text = ds.Tables[0].Rows[0][0].ToString();
            Label4.Text = ds.Tables[0].Rows[0][1].ToString();
            Label6.Text = ds.Tables[0].Rows[0][2].ToString();
            Label8.Text = ds.Tables[0].Rows[0][3].ToString();
        }
    }
}