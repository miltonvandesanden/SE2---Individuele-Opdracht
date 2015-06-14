using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE2___Individuele_Opdracht.InterfaceLayer
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        private LoginControl loginControl = new LoginControl();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAccountCreationCreate_Click(object sender, EventArgs e)
        {
            if (loginControl.CreateAccount(tbAccountCreationUsername.Text, tbAccountCreationPassword.Text, tbAccountCreationEmail.Text, tbAccountCreationPostalcode.Text, Convert.ToInt32(tbAccountCreationPhone.Text)))
            {
                
            }
        }
    }
}