using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace SE2___Individuele_Opdracht
{
    /// <summary>
    /// beheerd alles wat er met users gebeurd binnen de applicatie
    /// </summary>
    public class UserControl
    {
        private DbUserControl dbUserControl = new DbUserControl();
        public List<User> Users { get; set; }
        public UserControl()
        {
            GetAllUsers();
        }
        /// <summary>
        /// roept de CreateUser method uit de DbUserControl class aan om een nieuwe user te creeëren
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <param name="postalcode"></param>
        public void CreateUser(string userName, string userPassword, string email, int phone, string postalcode)
        {
            dbUserControl.CreateUser(userName, userPassword, email, phone, postalcode);
            GetAllUsers();
        }

        /// <summary>
        /// vult de lokale List met users uit de database
        /// </summary>
        public void GetAllUsers()
        {
            Users = dbUserControl.GetAllUsers();
        }
    }
}
