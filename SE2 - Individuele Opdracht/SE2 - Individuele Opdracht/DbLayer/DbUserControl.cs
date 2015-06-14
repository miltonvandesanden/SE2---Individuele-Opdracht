using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using Oracle.DataAccess.Client;

namespace SE2___Individuele_Opdracht
{
    public class DbUserControl : DbConnection
    {
        public void CreateUser()
        {
            throw new System.NotImplementedException();
        }

        public void CheckUser()
        {
            throw new System.NotImplementedException();
        }

        public void GetUser()
        {
            throw new System.NotImplementedException();
        }

        public List<User> GetAllUser()
        {
            List<User> users = new List<User>();

            OracleCommand oracleCommand = OracleConnection.CreateCommand();
            OracleDataReader oracleDataReader;

            oracleCommand.CommandText = "SELECT userName, userPassword, email, phoneNumber, postalcode emailPref, paymentPref, receiptPref FROM SE2_User";

            oracleDataReader = oracleCommand.ExecuteReader();

            while (oracleDataReader.Read())
            {

            }
        }

        public List<Advert> GetAllAdvertsOfUser(int userID)
        {
            List<Advert> adverts = new List<Advert>();
            OracleCommand oracleCommand;
            OracleDataReader oracleDataReader;

            oracleCommand = OracleConnection.CreateCommand();
            oracleCommand.CommandText = "SELECT advertID, title, creationDate, views, serviceOrGood, categoryID FROM SE2_Advert WHERE userID = :userID";
            oracleCommand.Parameters.Add("userID", userID);

            oracleDataReader = oracleCommand.ExecuteReader();

            while (oracleDataReader.Read())
            {
                adverts.Add(new Advert());
            }
        }
    }
}
