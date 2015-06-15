using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace SE2___Individuele_Opdracht
{
    /// <summary>
    /// beheerd het in en uitloggen van gebruikers
    /// </summary>
    public class LoginControl
    {
        private DbLoginControl dbLoginControl = new DbLoginControl();

        /// <summary>
        /// logged een gebruiker in met behulp van de ingevulde username en password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string username, string password)
        {
            return dbLoginControl.Login(username, password);
        }

        /// <summary>
        /// logged een reeds ingelogde gebruiker uit
        /// </summary>
        public void Logout()
        {
        }
    }
}
