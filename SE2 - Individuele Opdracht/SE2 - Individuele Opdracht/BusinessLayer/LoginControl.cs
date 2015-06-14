using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace SE2___Individuele_Opdracht
{
    public class LoginControl
    {
        private DbLoginControl dbLoginControl = new DbLoginControl();
        public bool Login(string username, string password)
        {
            return dbLoginControl.Login(username, password);
        }

        public void Logout()
        {
            throw new System.NotImplementedException();
        }
    }
}
