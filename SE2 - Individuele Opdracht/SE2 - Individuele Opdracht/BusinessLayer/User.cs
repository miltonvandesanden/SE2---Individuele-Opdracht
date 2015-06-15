using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace SE2___Individuele_Opdracht
{
    /// <summary>
    /// bewaard alle info over Users
    /// </summary>
    public class User
    {
        public int UserID {get; set;}
        public string UserName {get; set;}
        public string UserPassword {get; set;}
        public string Email {get; set; }
        public int Phonenumber {get; set; }
        public int PostalcodeID { get; set; }
        public bool EmailPref{get; set;}
        public bool PaymentPref{get; set;}
        public bool ReceiptPref{get; set; }
        public List<int> AdvertID{get; set;}

        public User(int userId, string userName, string userPassword, string email, int phonenumber, int postalcodeID, bool emailPref, bool paymentPref, bool receiptPref, List<int> advertId)
        {
            UserID = userId;
            UserName = userName;
            UserPassword = userPassword;
            Email = email;
            Phonenumber = phonenumber;
            PostalcodeID = postalcodeID;
            EmailPref = emailPref;
            PaymentPref = paymentPref;
            ReceiptPref = receiptPref;
            AdvertID = advertId;
        }
    }
}
