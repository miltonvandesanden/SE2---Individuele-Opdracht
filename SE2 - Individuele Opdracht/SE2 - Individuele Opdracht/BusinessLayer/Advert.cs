using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace SE2___Individuele_Opdracht
{
    public abstract class Advert
    {
        public int AdvertID { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public int Views { get; set; }
        public bool IsService { get; set; }
        public int UserID { get; set; }

        public Advert(int advertID, string title, DateTime creationDate, int views, bool isService, int userID)
        {
            AdvertID = advertID;
            Title = title;
            CreationDate = creationDate;
            Views = views;
            IsService = isService;
            UserID = userID;
        }
    }
}
