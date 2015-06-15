using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace SE2___Individuele_Opdracht
{
    //beheerd alles wat er gebeurd met offers binnen de applicatie
    public class OfferControl
    {
        public List<Offer> Offers { get; set; }
        private DbOfferControl dbOfferControl = new DbOfferControl();
        /// <summary>
        /// roept de CreateOffer method uit de DbOfferControl class aan om een nieuwe offer te creeëren
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="userID"></param>
        /// <param name="advertID"></param>
        public void CreateOffer(int amount, int userID, int advertID)
        {
            dbOfferControl.CreateOffer(amount, userID, advertID);
        }

        /// <summary>
        /// roept de DeleteOffer method uit de DbOfferControl class aan om een bestaande offer te verwijderen
        /// </summary>
        /// <param name="offerID"></param>
        /// <param name="userID"></param>
        /// <param name="advertID"></param>
        public void DeleteOffer(int offerID, int userID, int advertID)
        {
            dbOfferControl.DeleteOffer(offerID, userID, advertID);
        }

        /// <summary>
        /// vult de lokale List met offers uit de database
        /// </summary>
        public void GetAllOffers()
        {
            Offers = dbOfferControl.GetAllOffers();
        }
    }
}
