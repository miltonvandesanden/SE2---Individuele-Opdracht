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
        private UserControl userControl = new UserControl();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAccountCreationCreate_Click(object sender, EventArgs e)
        {
            userControl.CreateUser(tbAccountCreationUsername.Text, tbAccountCreationPassword.Text, tbAccountCreationEmail.Text, Convert.ToInt32(tbAccountCreationPhone.Text), tbAccountCreationPostalcode.Text);
        }
    }
}