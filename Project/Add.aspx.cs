using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using mshtml;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;
using System.Data.SqlClient;

public partial class Add : System.Web.UI.Page
{    
    SqlConnection con = new SqlConnection(@"Data Source=HDAVE;Initial Catalog=Phishing;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["add"] == "add")
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "msgtype", "alert('Data Added !!!')", true);
            Session["add"] = "";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
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
        Label2.Text = title;

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
                    // int mcount = 0;
                    Label3.Text = meta.content;
                }


            }
        }
        con.Open();
        string i1 = "insert into blist values('" + TextBox1.Text + "','" + Label2.Text + "','" + Label3.Text + "')";
        SqlCommand cmd = new SqlCommand(i1, con);
        cmd.ExecuteNonQuery();
        con.Close();
        Session["add"] = "add";
        Response.Redirect("Add.aspx");
    }
}