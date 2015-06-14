using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace SE2___Individuele_Opdracht
{
    public class Offer
    {
        public int Ammount { get; set; }
        public int AdvertID { get; set; }
        public int UserID { get; set; }

        public Offer(int ammount, int advertId, int userId)
        {
            Ammount = ammount;
            AdvertID = advertId;
            UserID = userId;
        }
    }
}
