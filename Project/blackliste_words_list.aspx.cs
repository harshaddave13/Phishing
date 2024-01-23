using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class blackliste_words_list : System.Web.UI.Page
{    
    SqlConnection con = new SqlConnection(@"Data Source=HDAVE;Initial Catalog=Phishing;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {
      
            Panel1.Visible = false;
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string op = "select word from keyword";
            da = new SqlDataAdapter(op, con);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "yes")
        {
            string i = Convert.ToString(e.CommandArgument.ToString());
            Panel1.Visible = true;
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string kl = "select word from keyword where word='" + i + "'";
            da = new SqlDataAdapter(kl, con);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                TextBox1.Text = ds.Tables[0].Rows[0][0].ToString();
            }

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            SqlCommand cmd;
            con.Open();
            string l = "insert into bwords values('" + TextBox1.Text + "')";
            cmd = new SqlCommand(l, con);
            cmd.ExecuteNonQuery();
            con.Close();
            SqlCommand cmd1;
            con.Open();
            string m = "delete from Keyword where word='" + TextBox1.Text + "'";
            cmd1 = new SqlCommand(m, con);
            cmd1.ExecuteNonQuery();
            con.Close();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string op = "select word from keyword";
            da = new SqlDataAdapter(op, con);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
        else
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string ol = "select words from bwords where words='" + TextBox1.Text + "'";
            da = new SqlDataAdapter(ol, con);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                SqlCommand cmd;
                con.Open();
                string m = "delete from bwords where words='" + TextBox1.Text + "'";
                cmd = new SqlCommand(m, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            SqlCommand cmd1;
            con.Open();
            string n = "delete from Keyword where word='" + TextBox1.Text + "'";
            cmd1 = new SqlCommand(n, con);
            cmd1.ExecuteNonQuery();
            con.Close();
            SqlDataAdapter da1;
            DataSet ds1 = new DataSet();
            string op = "select word from keyword";
            da1 = new SqlDataAdapter(op, con);
            da1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds1;
                GridView1.DataBind();
            }
            
        }
      

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        string op = "select word from keyword";
        da = new SqlDataAdapter(op, con);
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}