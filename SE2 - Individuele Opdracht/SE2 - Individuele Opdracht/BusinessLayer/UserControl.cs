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
        public void CreateUser()
        {
            throw new System.NotImplementedException();
        }

        public void CheckUser()
        {
            throw new System.NotImplementedException();
        }

        public void GetUser()
        {
            throw new System.NotImplementedException();
        }

        public void GetAllUsers()
        {
            
        }

        public List<Advert> GetAllAdvertsOfUser(int userID)
        {
            
        }
    }
}
