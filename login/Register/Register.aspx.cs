using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Security;

public partial class Register_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
         
            string CS = ConfigurationManager.ConnectionStrings["loginEntities"].ConnectionString;
          
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spRegisterUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter username = new SqlParameter("@UserName", txtUserName.Text);
              
              
                SqlParameter password = new SqlParameter("@Password", txtPassword.Text);
                SqlParameter email = new SqlParameter("@Email", txtEmail.Text);

                cmd.Parameters.Add(username);
                cmd.Parameters.Add(password);
                cmd.Parameters.Add(email);

                con.Open();
                int ReturnCode = (int)cmd.ExecuteScalar();
                if (ReturnCode == -1)
                {
                    lblMessage.Text = "User Name already in use, please choose another user name";
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
    }
}