using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace SE2___Individuele_Opdracht
{
    /// <summary>
    /// deze class beheerd alles wat er met adverts gebeurd binnen de applicatie
    /// </summary>
    public class AdvertControl
    {
        private DbAdvertControl dbAdvertControl;
        public List<Advert> Adverts { get; set; }

        /// <summary>
        /// roept de CreateService method uit de DbAdvertControl class aan om een nieuwe service te creeëren
        /// </summary>
        /// <param name="title"></param>
        /// <param name="isService"></param>
        /// <param name="userID"></param>
        /// <param name="categoryID"></param>
        /// <param name="experience"></param>
        /// <param name="employees"></param>
        /// <param name="companyType"></param>
        public void CreateService(string title, bool isService, int userID, int categoryID, string experience,
            string employees, string companyType)
        {
            dbAdvertControl.CreateService(title, isService, userID, categoryID, experience, employees, companyType);
            GetAllAdverts();
        }

        /// <summary>
        /// roept de CreateGood method uit de DbAdvertControl class aan om een nieuwe good te creeëren
        /// </summary>
        /// <param name="title"></param>
        /// <param name="isService"></param>
        /// <param name="userID"></param>
        /// <param name="categoryID"></param>
        /// <param name="condition"></param>
        public void CreateGood (string title, bool isService, int userID, int categoryID, string condition)
        {
            dbAdvertControl.CreateGood(title, isService, userID, categoryID, condition);
            GetAllAdverts();
        }

        /// <summary>
        /// roept de DeleteAdvert method uit de DbAdvertControl class aan om een advert te verwijderen
        /// </summary>
        /// <param name="advertID"></param>
        /// <param name="isService"></param>
        public void DeleteAdvert(int advertID, bool isService)
        {
            dbAdvertControl.DeleteAdvert(advertID, isService);
            GetAllAdverts();
        }

        /// <summary>
        /// vult de lijst met adverts met de return lijst van de method GetAllAdverts van de class DbAdvertControl
        /// </summary>
        public void GetAllAdverts()
        {
            Adverts = dbAdvertControl.GetAllAdverts();
        }
    }
}
