using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Web.UI.WebControls;

namespace SE2___Individuele_Opdracht
{
    /// <summary>
    /// bewaard alle info over de Goods
    /// </summary>
    public class Good : Advert
    {
        public string Condition { get; set; }

        public Good(int advertID, string title, DateTime creationDate, int views, bool isService, int userID, int categoryID, string condition) : base(advertID, title, creationDate, views, isService, userID, categoryID)
        {
            Condition = condition;
        }
    }
}
