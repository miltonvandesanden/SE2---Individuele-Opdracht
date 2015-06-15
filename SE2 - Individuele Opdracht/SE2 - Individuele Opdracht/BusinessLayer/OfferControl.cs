using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace SE2___Individuele_Opdracht
{
    public class OfferControl
    {
        public List<Offer> Offers { get; set; }
        private DbOfferControl dbOfferControl = new DbOfferControl();
        public void CreateOffer(int amount, int userID, int advertID)
        {
            dbOfferControl.CreateOffer(amount, userID, advertID);
        }

        public void DeleteOffer(int offerID, int userID, int advertID)
        {
            dbOfferControl.DeleteOffer(offerID, userID, advertID);
        }

        public void GetAllOffers()
        {
            Offers = dbOfferControl.GetAllOffers();
        }
    }
}
