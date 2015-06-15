using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace SE2___Individuele_Opdracht
{
    public class AdvertControl
    {
        private DbAdvertControl dbAdvertControl;
        public List<Advert> Adverts { get; set; }    
        public void CreateService(string title, bool isService, int userID, int categoryID, string experience,
            string employees, string companyType)
        {
            dbAdvertControl.CreateService(title, isService, userID, categoryID, experience, employees, companyType);
            GetAllAdverts();
        }

        public void CreateGood (string title, bool isService, int userID, int categoryID, string condition)
        {
            dbAdvertControl.CreateGood(title, isService, userID, categoryID, condition);
            GetAllAdverts();
        }

        public void DeleteAdvert(int advertID, bool isService)
        {
            dbAdvertControl.DeleteAdvert(advertID, isService);
            GetAllAdverts();
        }

        public void GetAllAdverts()
        {
            Adverts = dbAdvertControl.GetAllAdverts();
        }
    }
}
