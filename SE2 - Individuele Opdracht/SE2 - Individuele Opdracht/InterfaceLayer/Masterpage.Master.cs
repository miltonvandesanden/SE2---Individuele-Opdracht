using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE2___Individuele_Opdracht.InterfaceLayer
{
    public partial class Masterpage : System.Web.UI.MasterPage
    {
        private LoginControl loginControl = new LoginControl();
        private bool loggedIn;
        protected void Page_Load(object sender, EventArgs e)
        {
            loggedIn = false;
        }

        protected void btnLoginControlLog_Click(object sender, EventArgs e)
        {
            if (loggedIn)
            {
                loginControl.Logout();

                btnLoginControlLog.Text = "Log In";
                loggedIn = false;
            }
            else
            {
                if (loginControl.Login(tbLoginControlUsername.Text, tbLoginControlPassword.Text))
                {
                    loggedIn = true;
                    btnLoginControlLog.Text = "Log Out";
                }
                else
                {
                    lblLoginControlError.Text = "Log in failed!";
                    tbLoginControlUsername.Text = "";
                    tbLoginControlPassword.Text = "";
                }
            }
        }

        protected void linkbtnCreateUser_Click(object sender, EventArgs e)
        {

        }

        protected void linkbtnAdvertControlMyAdverts_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void linkbtnAdvertControlAdverts_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void linkbtnAdvertControl_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}