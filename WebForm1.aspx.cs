using Google.Apis.Admin.Directory.directory_v1.Data;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EncryptionDecryptionOfPassword
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string encrypwd;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EncryptDecryptConnection"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
   
        protected void Page_Load(object sender, EventArgs e)
        {
            conn.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text == TextBox3.Text)
            {
                encrytion();
                Label6.Text = " password matched  You have successfully Registered";
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
            }
            else
            {
                Label6.Text = " password did not matched ";
            }
        }

        private void encrytion()
        {
            string str = string.Empty;
            string username = TextBox1.Text;
            byte[] encode = new byte[TextBox3.Text.ToString().Length];
            encode = System.Text.Encoding.UTF8.GetBytes(TextBox3.Text);
            str = Convert.ToBase64String(encode);
            encrypwd = str;
            cmd = new SqlCommand("insert into Userlogin(UserName,UserPassword) values(@username,@encrypwd)", conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@encrypwd", encrypwd);
            cmd.ExecuteNonQuery();

        }
    }
}