using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EncryptionDecryptionOfPassword
{
    public partial class LoginPage : System.Web.UI.Page
    {
       static string decrypwd;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EncryptDecryptConnection"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
       
      
        protected void Page_Load(object sender, EventArgs e)
        {
            conn.Open();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text;
            cmd = new SqlCommand("select * from Userlogin where UserName =@username",conn);
            cmd.Parameters.AddWithValue("@username", username);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand =cmd;
            da.Fill(ds);
            string uname;
            string pass;
            if (ds.Tables[0].Rows.Count>0)
            {
                uname = ds.Tables[0].Rows[0]["UserName"].ToString();
                pass = ds.Tables[0].Rows[0]["UserPassword"].ToString();
                conn.Close();
                decryptpassword(pass);
                if(uname==TextBox1.Text && decrypwd == TextBox2.Text)
                {
                    Session["UserName"] = uname;
                    Response.Redirect("success.aspx");
                }
                else
                {
                    Label3.Text = "Invaild Login Details" ;
                }

            }
            else
            {
                Label3.Text = "Invaild Login Details";
            }
        }

        private void decryptpassword(string encrytpwd)
        {
            string decpwd = string.Empty;
            UTF8Encoding encoding = new UTF8Encoding();
            Decoder decode = encoding.GetDecoder();
            byte[] todecode = Convert.FromBase64String(encrytpwd);
            int charcount = decode.GetCharCount(todecode, 0, todecode.Length);
            char[] decode_char = new char[charcount];
            decode.GetChars(todecode, 0, todecode.Length, decode_char, 0);
            decpwd = new string(decode_char);
            decrypwd = decpwd;
            
        }
    }
}