using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if ((txtUserName.Text=="nimesh")&&(txtPassword.Text=="1234"))
        { 
            
            FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, checkBoxRememberMe.Checked);

        }
        else
        {
            lblMessage.Text = "user name or password not correct";


        }

    }
}