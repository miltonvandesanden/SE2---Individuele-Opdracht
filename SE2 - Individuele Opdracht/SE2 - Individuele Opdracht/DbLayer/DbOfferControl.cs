using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using Oracle.DataAccess.Client;

namespace SE2___Individuele_Opdracht
{
    /// <summary>
    /// deze class vormt de verbinding tussen de class OfferControl en de database
    /// </summary>
    public class DbOfferControl : DbConnection
    {
        /// <summary>
        /// creeërt een nieuwe Offer in de database.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="userID"></param>
        /// <param name="advertID"></param>
        public void CreateOffer(int amount, int userID, int advertID)
        {
            if (!CheckOffer(userID, advertID))
            {
                try
                {
                    OracleCommand oracleCommand;

                    OracleConnection.Open();
                    oracleCommand = OracleConnection.CreateCommand();

                    oracleCommand.CommandText =
                        "INSERT INTO SE2_Offer(amount, userID, advertID) VALUES (:amount, :userID, :advertID)";
                    oracleCommand.Parameters.Add(new OracleParameter("amount", amount));
                    oracleCommand.Parameters.Add(new OracleParameter("userID", userID));
                    oracleCommand.Parameters.Add(new OracleParameter("advertID", advertID));

                    oracleCommand.ExecuteNonQuery();
                }
                catch (Exception exception)
                {

                    throw exception;
                }
                finally
                {
                    try
                    {
                        OracleConnection.Close();
                    }
                    catch (Exception exception)
                    {

                        throw exception;
                    }
                }
            }
        }

        /// <summary>
        /// checked met behulp van het userID en het advertID of de Offer al in de database voorkomt,
        /// returned true indien dit zo is
        /// returned false indien dit niet zo is
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="advertID"></param>
        /// <returns></returns>
        private bool CheckOffer(int userID, int advertID)
        {
            bool result = false;

            try
            {
                OracleCommand oracleCommand;
                OracleDataReader oracleDataReader;

                OracleConnection.Open();
                oracleCommand = OracleConnection.CreateCommand();

                oracleCommand.CommandText =
                    "SELECT offerID FROM SE2_Offer WHERE userID = :userID AND advertID = :advertID";
                oracleCommand.Parameters.Add(new OracleParameter("userID", userID));
                oracleCommand.Parameters.Add(new OracleParameter("advertID", advertID));

                oracleDataReader = oracleCommand.ExecuteReader();

                if (oracleDataReader.HasRows)
                {
                    result = true;
                }
            }
            catch (Exception exception)
            {

                throw exception;
            }
            finally
            {
                try
                {
                    OracleConnection.Close();
                }
                catch (Exception exception)
                {
                    
                    throw exception;
                }
            }

            return result;
        }

        /// <summary>
        /// verwijderd een offer uit de database
        /// </summary>
        /// <param name="offerID"></param>
        /// <param name="userID"></param>
        /// <param name="advertID"></param>
        public void DeleteOffer(int offerID, int userID, int advertID)
        {
            if (CheckOffer(userID, advertID))
            {
                try
                {
                    OracleCommand oracleCommand;

                    OracleConnection.Open();
                    oracleCommand = OracleConnection.CreateCommand();

                    oracleCommand.CommandText = "DELETE FROM SE2_Offer WHERE offerID = :offerID";
                    oracleCommand.Parameters.Add(new OracleParameter("offerID", offerID));

                    oracleCommand.ExecuteNonQuery();
                }
                catch (Exception exception)
                {

                    throw exception;
                }
                finally
                {
                    try
                    {
                        OracleConnection.Close();
                    }
                    catch (Exception exception)
                    {
                        
                        throw exception;
                    }
                }
            }
        }

        /// <summary>
        /// haalt alle offers uit de database en returned deze als een lijst met Offer classes
        /// </summary>
        /// <returns></returns>
        public List<Offer> GetAllOffers()
        {
            List<Offer> offers = new List<Offer>();

            try
            {
                OracleCommand oracleCommand;
                OracleDataReader oracleDataReader;

                OracleConnection.Open();
                oracleCommand = OracleConnection.CreateCommand();

                oracleCommand.CommandText = "SELECT offerID, amount, userID, advertID FROM SE2_Offer";

                oracleDataReader = oracleCommand.ExecuteReader();

                if (oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        int offerID = Convert.ToInt32(oracleDataReader["offerID"]);
                        int amount = Convert.ToInt32(oracleDataReader["amount"]);
                        int userID = Convert.ToInt32(oracleDataReader["userID"]);
                        int advertID = Convert.ToInt32(oracleDataReader["advertID"]);

                        offers.Add(new Offer(offerID, amount, userID, advertID));
                    }
                }
            }
            catch (Exception exception)
            {

                throw exception;
            }
            finally
            {
                try
                {
                    OracleConnection.Close();
                }
                catch (Exception exception)
                {
                    
                    throw exception;
                }
            }

            return offers;
        }
    }
}
