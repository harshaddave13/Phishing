using System;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.IO;
using mshtml;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;

public partial class Web : System.Web.UI.Page
{    
    SqlConnection con = new SqlConnection(@"Data Source=HDAVE;Initial Catalog=Phishing;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
       // Label2.Text = "0";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        

        I1.Visible = true;
        try
        {
            string URL = TextBox1.Text;
            if (TextBox1.Text != "")
            {
                I1.Attributes.Add("src", URL);
            }

            // Create a request for the URL.
            string url = TextBox1.Text;
            WebRequest request = WebRequest.Create(url);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.
            Console.WriteLine(response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.


            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();



            //reads the html into an html document to enable parsing
            IHTMLDocument2 doc = new HTMLDocumentClass();
            doc.write(new object[] { responseFromServer });
            doc.close();

            WebClient x = new WebClient();
            string source = x.DownloadString(TextBox1.Text.ToString());
            string title = Regex.Match(source, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
            title1.Text = title;

            //loops through each element in the document to check if it qualifies for the attributes to be set
            foreach (IHTMLElement el in (IHTMLElementCollection)doc.all)
            {
                // check to see if all the desired attributes were found with the correct values

                if (el.tagName == "META")
                {
                    HTMLMetaElement meta = (HTMLMetaElement)el;
                    if (meta.name == "keywords")
                    {
                        int kcount = 0;

                        String[] sent = meta.content.Split(',');
                        foreach (string word in sent)
                        {


                            String[] words = word.Split(',');
                            foreach (string sword in words)
                            {

                                Console.WriteLine(sword);

                            }
                            kcount = kcount + 1;


                        }
                      //  Label3.Text = Convert.ToString(kcount);
                        if (kcount >= 10)
                        {
                          //  Label4.Text = "Too Many Keywords! Try to keep your keyword count below 10 for a single page";
                        }
                        else
                        {
                           // Label4.Text = "Keyword count is good";
                        }
                    }
                    else if (meta.name == "description")
                    {
                        int mcount = 0;
                        Label5.Text = meta.content;
                        foreach (char c in meta.content)
                        {
                            mcount++;
                        }
                       // Label6.Text = "Description length=" + mcount;
                        if (mcount >= 160)
                        {
                           // Label7.Text = "Description too long !Try to keep your description within 100-160 characters";
                        }
                        else if (mcount < 100)
                        {
                           // Label7.Text = "Description too short !Try to keep your description within 100-160 characters";
                        }
                        else
                        {
                           // Label7.Text = "Description length good";
                        }

                    }


                } Console.ReadLine();

            }
        }
        catch (UriFormatException)
        {
            String alertmsg = "Enter Proper Url Starting with http://";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + alertmsg + "');", true);

        }
       


        string url1 = TextBox1.Text;
        string s4 = "select url,title,desn from blist where url='"+TextBox1.Text+"'";
        SqlDataAdapter sda4 = new SqlDataAdapter(s4, con);
        DataSet ds4 = new DataSet();
        sda4.Fill(ds4);
        int flag = 0;
        int cc = ds4.Tables[0].Rows.Count;
        cc = cc - 1;
       
        if (ds4.Tables[0].Rows.Count > 0)
        {
            Label9.Text = "Blacklisted Website";
            Label9.ForeColor = System.Drawing.Color.Red;
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('This website is Phishing Website!!!'", true);   

        }

        else
        {
            Label9.Text = "Not Blacklisted Website";
            Label2.Text = "0";
            Label9.ForeColor = System.Drawing.Color.Black;
            string ks = "select * from bwords";
            SqlDataAdapter sda1 = new SqlDataAdapter(ks, con);
            DataSet dss = new DataSet();
            sda1.Fill(dss);

            int cnt = dss.Tables[0].Rows.Count;
            int words = 0;
            while (cnt > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    string t1 = TextBox1.Text;
                    string ks1 = dss.Tables[0].Rows[i][0].ToString();
                    if (words == 0)
                    {
                        if (t1.Contains(ks1))
                        {
                            words = 1;
                            int ccc = Convert.ToInt32(Label2.Text) - 1;
                            Label6.Text = "The URL contains Blacklisted Words!!!";
                            Label6.ForeColor = System.Drawing.Color.Red;
                            Label6.Visible = true;
                            Label2.Text = ccc.ToString();
                            break;

                        }

                    }
                    if (words == 1)
                    {
                        int ccc = Convert.ToInt32(Label2.Text) + 1;
                        Label2.Text = ccc.ToString();
                        break;
                    }
                }
                if (words == 1)
                {
                    break;
                }

                cnt--;
            }
            if (words == 0)
            {
                Label6.Text = "The URL does not contain Blacklisted Words!!!";
                Label6.ForeColor = System.Drawing.Color.Black;
            }
            string s = TextBox1.Text;
            string s1 = s.Remove(0, 5);
            if (s1 == "https")
            {
                int c = Convert.ToInt32(Label2.Text) + 1;
                Label2.Text = c.ToString();
                Label7.Visible = true;
                Label7.Text = "The website is secure since it uses https ";
                Label7.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                int c = Convert.ToInt32(Label2.Text) - 1;
                Label7.Text = "The website may not be secure since it uses http instead of https";
                Label7.ForeColor = System.Drawing.Color.Red;
                Label7.Visible = true;
                Label2.Text = c.ToString();
            }

            string[] ss2 = url1.Split('.');
            string chk = "select url,title,desn from chklist";
            SqlDataAdapter sda = new SqlDataAdapter(chk, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int flag1 = 0;
            int cc1 = ds.Tables[0].Rows.Count - 1;
            if (ds.Tables[0].Rows.Count > 0)
            {
                while (cc1 >= 0)
                {
                    for (int i = 0; i < ss2.Length; i++)
                    {
                        ss2[i] = ss2[i].ToLower();
                        if (flag1 == 0)
                        {
                            if (ds.Tables[0].Rows[cc1][0].ToString().Contains(ss2[i]))
                            {

                                string sss = ds.Tables[0].Rows[cc1][2].ToString();
                                string tit = ds.Tables[0].Rows[cc1][1].ToString();
                                string s0 = title1.Text;
                                title1.Text = s0.Replace("\r\n", "");
                                if (ds.Tables[0].Rows[cc1][1].ToString() == title1.Text && ds.Tables[0].Rows[cc1][2].ToString() == Label5.Text)
                                {
                                    Label8.Text = "The url,title and description is found";
                                    Label8.ForeColor = System.Drawing.Color.Black;
                                    flag1 = 1;
                                    int l2 = Convert.ToInt32(Label2.Text) + 2;
                                    Label2.Text = l2.ToString();
                                    break;
                                }

                            }

                        }
                        if (flag1 == 0)
                        {
                            Label8.Text = "The url,title and description is not found";
                            Label8.ForeColor = System.Drawing.Color.Red;
                            break;
                        }

                    }
                    cc1--;
                }//while     

            }//if
            string str1 = "select * from list where url='" + TextBox1.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(str1, con);
            DataSet sds = new DataSet();
            da.Fill(sds);

            if (sds.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                if (Convert.ToInt32(Label2.Text) < 0)
                {
                    con.Open();
                    string s6 = "insert into list values('" + TextBox1.Text + "','" + Label2.Text + "','Yes')";
                    SqlCommand cmd1 = new SqlCommand(s6, con);
                    cmd1.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    string s5 = "insert into blist values('" + TextBox1.Text + "','" + title1.Text + "','" + Label5.Text + "')";
                    SqlCommand cmd = new SqlCommand(s5, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('This Website may be Phishing Website')", true);

                }
                else
                {
                    con.Open();
                    string s6 = "insert into list values('" + TextBox1.Text + "','" + Label2.Text + "','No')";
                    SqlCommand cmd1 = new SqlCommand(s6, con);
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }
            }

        }//else

        
      /*  if (Convert.ToInt32(Label2.Text)<= 0)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
        }
        else
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
        }*/
    }
}
