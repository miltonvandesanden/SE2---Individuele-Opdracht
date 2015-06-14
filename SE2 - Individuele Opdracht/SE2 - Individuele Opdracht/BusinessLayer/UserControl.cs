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
        private List<User> users = new List<User>();
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
            foreach (User user in users)
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
            users = dbUserControl.GetAllUsers();
        }
    }
}
