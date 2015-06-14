using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace SE2___Individuele_Opdracht
{
    public class User
    {
        public int userID {get; set;}
        public string userName {get; set;}
        public string userPassword {get; set;}
        public string email {get; set; }
        public int phonenumber {get; set; }
        public bool emailPref{get; set;}
        public bool paymentPref{get; set;}
        public bool receiptPref{get; set; }
        public List<Advert> Adverts{get; set;}

        public User(int userID, string userName, string userPassword, string email, int phonenumber, bool emailPref, bool receiptPref, bool paymentPref)
        {
            this.userID = userID;
            this.userName = userName;
            this.userPassword = userPassword;
            this.email = email;
            this.phonenumber = phonenumber;
            this.emailPref = emailPref;
            this.receiptPref = receiptPref;
            this.paymentPref = paymentPref;
        }
    }
}
