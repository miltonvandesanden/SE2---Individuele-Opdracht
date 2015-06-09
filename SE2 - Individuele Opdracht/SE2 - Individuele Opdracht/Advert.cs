using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace SE2___Individuele_Opdracht
{
    public abstract class Advert
    {
        public int advertID
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string title
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public DateTime creationDate
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int views
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public bool service
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int userID
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public User User
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void GetOwner()
        {
            throw new System.NotImplementedException();
        }
    }
}
