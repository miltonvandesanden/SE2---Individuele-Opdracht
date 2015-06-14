using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Web.UI.WebControls;

namespace SE2___Individuele_Opdracht
{
    public class Good : Advert
    {
        public string Condition { get; set; }

        public Good(int advertID, string title, DateTime creationDate, int views, bool isService, int userID, string condition) : base(advertID, title, creationDate, views, isService, userID)
        {
            Condition = condition;
        }
    }
}
