using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace SE2___Individuele_Opdracht
{
    public class Offer
    {
        public int OfferID { get; set; }
        public int Ammount { get; set; }
        public int AdvertID { get; set; }
        public int UserID { get; set; }

        public Offer(int offerID, int ammount, int advertId, int userId)
        {
            OfferID = offerID;
            Ammount = ammount;
            AdvertID = advertId;
            UserID = userId;
        }
    }
}
