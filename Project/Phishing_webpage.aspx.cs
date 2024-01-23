using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mshtml;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;


public partial class Phishing_webpage : System.Web.UI.Page
{    
    SqlConnection con = new SqlConnection(@"Data Source=HDAVE;Initial Catalog=Phishing;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        Label3.Text = "";
        Label4.Text = "";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        SqlDataReader dr;
        
        //initializing score to 0. Lower the score lower the Risk
        int score = 0;

        //Setuping Up IFrame
        I1.Visible = true;
        string URL = TextBox1.Text;
        if (TextBox1.Text != "")
        {
            I1.Attributes.Add("src", URL);
        }
        
        // Create a request for the URL.
        string url = TextBox1.Text;

        

        //Regex to check if string starts with http or https
        Regex rgx = new Regex(@"^(https)://.*$");
        if (!rgx.IsMatch(url))
        {
            Label4.Text = "This Site is Secured with Https";
            score -= 8;
        }
        else
        {
            //checking if domain is blacklisted 
            Uri myUri = new Uri(url);
            string baseUrl = myUri.Host;

            cmd = new SqlCommand("Select * from BList where url Like '%" + baseUrl + "%'", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                con.Close();

                //Check Specified URL is Present in BlackListed DataSet    
                string ol = "Select URL from blist Where url Like '%"+ url + "%'";
                cmd = new SqlCommand(ol,con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    con.Close();

                    //Url is found Blacklisted
                    Label4.Text += "<br/> This Website is Blacklisted by Admin";
                    
                    //Increasing Score
                    score += 15;
                }
                else
                {
                    con.Close();

                    //Url is not found BlackListed
                    Label4.Text += "<br/> This Website's Domain is Blacklisted by Admin";
                    
                    //Increasing Score as Domain is BlackListed
                    score += 5;
                }
            }
            else
            {
                con.Close();
                
                //Url is not found BlackListed
                Label4.Text += "<br/> This Website is <b>NOT Blacklisted</b> by Admin";
                
                //Reducing Score as URL Not found in BlackList
                score -= 1;
            
                //Clearing Data from previous check
                string fd = "delete from Newwords";
                cmd = new SqlCommand(fd, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                try
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                    // Reading the content of the URL.
                    WebRequest request = WebRequest.Create(url);
                    request.Credentials = CredentialCache.DefaultCredentials;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();

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
                    string str = "";

                    int countbwords = 0;

                    foreach (IHTMLElement el in (IHTMLElementCollection)doc.all)
                    {
                        // checking to see if the desired attributes are present with the correct values
                        if (el.tagName == "META")
                        {
                            HTMLMetaElement meta = (HTMLMetaElement)el;
                            if (meta.name == "keywords")
                            {
                                string[] sent = meta.content.Split(',');

                                foreach (string word in sent)
                                {
                                    insert(word);
                                    countbwords += countfun(word);
                                }
                            }

                            else if (meta.name == "description")
                            {
                                string ma = meta.content;
                                insert(ma);
                                countbwords += countfun(ma);
                            }
                        }
                    }


                    //count matching words in title
                    insert(title);
                    countbwords += countfun(title);

                    //extracting sentence
                    string txt = source.Replace("\n", " ");
                    txt = txt.Replace("\r", " ");
                    txt = txt.Replace("\t", " ");
                    txt = txt.Replace("&nbsp;", " ");
                    txt = txt.Replace("\"", " ");
                    txt = txt.Replace("'", " ");

                    char[] array = txt.ToCharArray();
                    int flag1 = -1;
                    // Loop through array.

                    //Removes Tags and its content and filters the content
                    for (int i = 0; i < array.Length; i++)
                    {
                        // Get character from array.
                        char letter = array[i];

                        if (letter == '<' || letter == '{' || letter == '(' || letter == '[')
                        {
                            flag1 = 0;
                        }
                        else if (flag1 == 1)
                        {
                            str = str + letter;
                        }
                        else if (letter == '>' || letter == '}' || letter == ')' || letter == ']')
                        {
                            flag1 = 1;
                            str = str + " ";
                        }
                    }

                    str = str.Trim();
                    str = str.Replace("[", " ");
                    str = str.Replace("]", " ");
                    str = str.Replace("<", " ");
                    str = str.Replace(">", " ");
                    str = str.Replace("{", " ");
                    str = str.Replace("}", " ");
                    str = str.Replace("(", " ");
                    str = str.Replace(")", " ");
                    str = str.Replace("\\", " ");
                    str = str.Replace(";", " ");
                    str = str.Replace("\\", " ");
                    str = str.Replace("/", " ");
                    str = str.Replace("\"", " ");
                    str = str.Replace("'", " ");
                    str = Regex.Replace(str, @"\s+", " ");
                    str = str.Replace("  ", " ");

                    string[] newL = str.Split(' ');

                    str = "";

                    for (int i = 0; i < newL.Length; i++)
                    {
                        if (!(newL[i].StartsWith(".")))
                        {
                            str += newL[i].ToString() + " ";
                        }
                    }

                    string[] splitSentences = Regex.Split(str, @"(?<=['""A-Za-z0-9][\.\!\?])\s+(?=[A-Z])");
                    string[] finalS = Regex.Split(str, @"(?<=['""A-Za-z0-9][\.\!\?])\s+(?=[A-Z])");
                    string[] newS = new string[splitSentences.Length];
                    for (int i = 0; i < splitSentences.Length; i++)
                    {
                        splitSentences[i] = splitSentences[i].Replace(@",", " ");
                        splitSentences[i] = splitSentences[i].Replace(@"'", " ");
                        splitSentences[i] = splitSentences[i].Replace(@".", " ");
                        splitSentences[i] = splitSentences[i].Replace(@"\", " ");
                        //splitSentences[i] = splitSentences[i].Replace(@"\n", "");

                        string[] words = splitSentences[i].Split(' ');
                        foreach (string word1 in words)
                        {
                            string word = word1.Replace("'", "");

                            if (word.Equals(".") || word.Equals("a") || word.Equals("the") || word.Equals("An") || word.Equals("A") || word.Equals("This") || word.Equals("The") || word.Equals("he") || word.Equals("in") || word.Equals("our") || word.Equals("she") || word.Equals("is") || word.Equals("was") || word.Equals("then") || word.Equals("if") || word.Equals("to") || word.Equals("has") || word.Equals("had") || word.Equals("will") || word.Equals("with") || word.Equals("and") || word.Equals("or") || word.Equals("because") || word.Equals("since") || word.Equals("there") || word.Equals("here") || word.Equals("of") || word.Equals("at") || word.Equals("with") || word.Equals("give") || word.Equals("take") || word.Equals("till") || word.Equals("for") || word.Equals("do") || word.Equals("an") || word.Equals("as") || word.Equals("that") || word.Equals("can") || word.Equals("this") || word.Equals("be") || word.Equals("by") || word.Equals("are") || word.Equals("not") || word.Equals("some") || word.Equals("may") || word.Equals("other") || word.Equals("so") || word.Equals("such") || word.Equals("cause") == true)
                            { }
                            else
                            {
                                cmd = new SqlCommand("Select words from bwords where Words = '" + word + "'", con);
                                con.Open();
                                dr = cmd.ExecuteReader();
                                if (dr.HasRows)
                                {
                                    con.Close();
                                    newS[i] += word + " ";
                                    cmd = new SqlCommand("Select Count from NewWords where Word = '" + word + "'", con);
                                    con.Open();
                                    dr = cmd.ExecuteReader();
                                    if (dr.HasRows)
                                    {
                                        dr.Read();
                                        int cou = Convert.ToInt32(dr[0].ToString());
                                        cou += 1;
                                        con.Close();
                                        cmd = new SqlCommand("Update NewWords set Count ='" + cou + "' where Word = '" + word + "'", con);
                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                        con.Close();
                                    }
                                    else
                                    {
                                        con.Close();
                                        cmd = new SqlCommand("Insert into NewWords Values ('" + word + "','1')", con);
                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                        con.Close();
                                    }
                                }
                                else
                                {
                                    con.Close();
                                }
                            }
                        }
                    }

                    score += countbwords;
                    
                    if (score < 3)
                    {
                        //Website is Not a Phishing Website
                        string t = "insert into list values('" + TextBox1.Text + "','" + score + "','No')";

                        cmd = new SqlCommand(t, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        //Display Results
                        Label3.Text = "This is Not a Phishing Website";
                        Label3.ForeColor = Color.Green;
                    }
                    else
                    {
                        //Website is Suspected as a Phishing Website
                        string t = "insert into list values('" + TextBox1.Text + "','" + score + "','Yes')";
                        cmd = new SqlCommand(t, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        //Display Results
                        Label3.Text = "This is Suspected as a Phishing Website";
                        Label3.ForeColor = Color.Red;

                        //Machine Learning Part
                        da = new SqlDataAdapter("Select Word,Count from NewWords where Count >=10", con);
                        ds = new DataSet();
                        da.Fill(ds);
                        int Ckey = ds.Tables[0].Rows.Count;

                        for (int i = 0; i < Ckey; i++)
                        {
                            string kword = ds.Tables[0].Rows[i][0].ToString();
                            SqlDataAdapter da5;
                            DataSet ds5 = new DataSet();
                            string mk = "select word from Keyword where word='" + kword + "'";
                            da5 = new SqlDataAdapter(mk, con);
                            da5.Fill(ds5);
                            if (ds5.Tables[0].Rows.Count > 0)
                            {
                                ds = new DataSet();
                                string kl = "select words from bwords where words='" + kword + "'";
                                da = new SqlDataAdapter(kl, con);
                                da.Fill(ds);
                                if (ds.Tables[0].Rows.Count <= 0)
                                {
                                    cmd = new SqlCommand("Insert Into keyword Values ('" + kword + "')", con);
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                            }
                        }
                    }
                }
                catch (UriFormatException)
                {
                    String alertmsg = "Enter Proper Url Starting with http://";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + alertmsg + "');", true);
                }
            }
        }
    }

    int countfun(string str)
    {
        int count = 0;
        string[] ss = str.Split(' ');
        foreach (string word1 in ss)
        {
            string word = word1.Replace("'","");
            if (word.Equals(".") || word.Equals("a") || word.Equals("the") || word.Equals("An") || word.Equals("A") || word.Equals("This") || word.Equals("The") || word.Equals("he") || word.Equals("in") || word.Equals("our") || word.Equals("she") || word.Equals("is") || word.Equals("was") || word.Equals("then") || word.Equals("if") || word.Equals("to") || word.Equals("has") || word.Equals("had") || word.Equals("will") || word.Equals("with") || word.Equals("and") || word.Equals("or") || word.Equals("because") || word.Equals("since") || word.Equals("there") || word.Equals("here") || word.Equals("of") || word.Equals("at") || word.Equals("with") || word.Equals("give") || word.Equals("take") || word.Equals("till") || word.Equals("for") || word.Equals("do") || word.Equals("an") || word.Equals("as") || word.Equals("that") || word.Equals("can") || word.Equals("this") || word.Equals("be") == true)
            { }
            else
            {
                SqlDataAdapter da;
                DataSet ds = new DataSet();
                string m = "select words from bwords where words='" + word + "'";
                da = new SqlDataAdapter(m, con);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    count = count + 1;
                }
            }
        }
        return count;
    }

    void insert(string words)
    {
        string[] ss = words.Split(' ');
        foreach (string word1 in ss)
        {
            string word = word1.Replace("'", "");
            if (word.Equals(".") || word.Equals("a") || word.Equals("the") || word.Equals("An") || word.Equals("A") || word.Equals("This") || word.Equals("The") || word.Equals("he") || word.Equals("in") || word.Equals("our") || word.Equals("she") || word.Equals("is") || word.Equals("was") || word.Equals("then") || word.Equals("if") || word.Equals("to") || word.Equals("has") || word.Equals("had") || word.Equals("will") || word.Equals("with") || word.Equals("and") || word.Equals("or") || word.Equals("because") || word.Equals("since") || word.Equals("there") || word.Equals("here") || word.Equals("of") || word.Equals("at") || word.Equals("with") || word.Equals("give") || word.Equals("take") || word.Equals("till") || word.Equals("for") || word.Equals("do") || word.Equals("an") || word.Equals("as") || word.Equals("that") || word.Equals("can") || word.Equals("this") || word.Equals("be") || word.Equals("by") || word.Equals("are") || word.Equals("not") || word.Equals("some") || word.Equals("may") || word.Equals("other") || word.Equals("so") || word.Equals("such") || word.Equals("cause") == true)
            { }
            else
            {
                SqlCommand cmd = new SqlCommand("Select words from bwords where Words = '" + word + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (!(dr.HasRows))
                {
                    con.Close();

                    cmd = new SqlCommand("Select Count from NewWords where Word = '" + word + "'", con);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        int cou = Convert.ToInt32(dr[0].ToString());
                        cou += 1;
                        con.Close();
                        cmd = new SqlCommand("Update NewWords set Count ='" + cou + "' where Word = '" + word + "'", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        con.Close();
                        cmd = new SqlCommand("Insert into NewWords Values ('" + word + "','1')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                else
                {
                    con.Close();
                }
            }
        }
    }
}