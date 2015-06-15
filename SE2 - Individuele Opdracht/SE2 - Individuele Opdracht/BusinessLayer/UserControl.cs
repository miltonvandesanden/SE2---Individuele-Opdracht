using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace SE2___Individuele_Opdracht
{
    public class UserControl
    {
        private DbUserControl dbUserControl = new DbUserControl();
        public List<User> Users { get; set; }
        public UserControl()
        {
            GetAllUsers();
        }
        public void CreateUser(string userName, string userPassword, string email, int phone, string postalcode)
        {
            dbUserControl.CreateUser(userName, userPassword, email, phone, postalcode);
            GetAllUsers();
        }
        public User GetUser(string username)
        {
            User result = null;
            foreach (User user in Users)
            {
                if (user.UserName == username)
                {
                    result = user;
                }
            }

            return result;
        }

        public void GetAllUsers()
        {
            Users = dbUserControl.GetAllUsers();
        }
    }
}
