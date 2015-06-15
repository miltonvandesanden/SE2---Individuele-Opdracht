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
    /// deze classvormd de verbinding tussen de class AdvertControl en de database.
    /// </summary>
    public class DbAdvertControl : DbConnection
    {
        /// <summary>
        /// Creates a new Service if there is no existing service with the same title
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
            if (!CheckAdvert(title))
            {
                CreateAdvert(title, isService, userID, categoryID);

                try
                {
                    OracleCommand oracleCommand;

                    OracleConnection.Open();

                    oracleCommand = OracleConnection.CreateCommand();

                    oracleCommand.CommandText =
                        "INSERT INTO SE2_Service (advertID, experience, employees, companyType) VALUES (:advertID, :experience, :employees, :companyType)";
                    oracleCommand.Parameters.Add(new OracleParameter("advertID", GetAdvertID(title)));
                    oracleCommand.Parameters.Add(new OracleParameter("experience", experience));
                    oracleCommand.Parameters.Add(new OracleParameter("employees", employees));
                    oracleCommand.Parameters.Add(new OracleParameter("companyType", companyType));

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
        /// returns de AdvertID property van de advert waarvan de title wordt meegegeven
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public int GetAdvertID(string title)
        {
            int advertID = -1;

            if (!CheckAdvert(title))
            {
                try
                {
                    OracleDataReader oracleDataReader;
                    OracleCommand oracleCommand;

                    OracleConnection.Open();

                    oracleCommand = OracleConnection.CreateCommand();

                    oracleCommand.CommandText = "SELECT advertID FROM SE2_Advert WHERE title = :title";
                    oracleCommand.Parameters.Add(new OracleParameter("title", title));

                    oracleDataReader = oracleCommand.ExecuteReader();

                    if (oracleDataReader.HasRows)
                    {
                        while (oracleDataReader.Read())
                        {
                            advertID = Convert.ToInt32(oracleDataReader["advertID"]);
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
            }

            return advertID;
        }

        /// <summary>
        /// creeërt een nieuwe advert
        /// </summary>
        /// <param name="title"></param>
        /// <param name="isService"></param>
        /// <param name="userID"></param>
        /// <param name="categoryID"></param>
        private void CreateAdvert(string title, bool isService, int userID, int categoryID)
        {
            try
            {
                OracleCommand oracleCommand;

                OracleConnection.Open();

                oracleCommand = OracleConnection.CreateCommand();

                oracleCommand.CommandText =
                    "INSERT INTO SE2_ADVERT (title, serviceOrGood, userID, categoryID) VALUES(:title, :serviceOrGood, :userID, :categoryID)";
                oracleCommand.Parameters.Add(new OracleParameter("title", title));
                if (isService)
                {
                    oracleCommand.Parameters.Add(new OracleParameter("serviceOrGood", 1));
                }
                else
                {
                    oracleCommand.Parameters.Add(new OracleParameter("serviceOrGood", 0));
                }
                oracleCommand.Parameters.Add(new OracleParameter("userID", userID));
                oracleCommand.Parameters.Add(new OracleParameter("categoryID", categoryID));
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

        /// <summary>
        /// creeërt een nieuwe Good indien er geen bestaande Good is met de meegegeven title
        /// </summary>
        /// <param name="title"></param>
        /// <param name="isService"></param>
        /// <param name="userID"></param>
        /// <param name="categoryID"></param>
        /// <param name="condition"></param>
        public void CreateGood(string title, bool isService, int userID, int categoryID, string condition)
        {
            if (!CheckAdvert(title))
            {
                CreateAdvert(title, isService, userID, categoryID);

                try
                {
                    OracleCommand oracleCommand;

                    OracleConnection.Open();

                    oracleCommand = OracleConnection.CreateCommand();

                    oracleCommand.CommandText =
                        "INSERT INTO SE2_Good (advertID, condition) VALUES (:advertID, :condition)";
                    oracleCommand.Parameters.Add(new OracleParameter("advertID", GetAdvertID(title)));
                    oracleCommand.Parameters.Add(new OracleParameter("condition", condition));

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
        /// Verwijderd een reeds bestaande Advert
        /// </summary>
        /// <param name="advertID"></param>
        /// <param name="isService"></param>
        public void DeleteAdvert(int advertID, bool isService)
        {
            if (isService)
            {
                DeleteService(advertID);
            }
            else
            {
                DeleteGood(advertID);
            }

            try
            {
                OracleCommand oracleCommand;

                OracleConnection.Open();
                oracleCommand = OracleConnection.CreateCommand();

                oracleCommand.CommandText = "DELETE FROM SE2_Advert WHERE advertID = :advertID";
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
        
        /// <summary>
        /// verwijderd een reeds bestaande service
        /// </summary>
        /// <param name="advertID"></param>
        private void DeleteService(int advertID)
        {
            try
            {
                OracleCommand oracleCommand;

                OracleConnection.Open();
                oracleCommand = OracleConnection.CreateCommand();

                oracleCommand.CommandText = "DELETE FROM SE2_Service WHERE advertID = :advertID";
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

        /// <summary>
        /// verwijderd een reeds bestaande Good
        /// </summary>
        /// <param name="advertID"></param>
        private void DeleteGood(int advertID)
        {
            try
            {
                OracleCommand oracleCommand;

                OracleConnection.Open();
                oracleCommand = OracleConnection.CreateCommand();

                oracleCommand.CommandText = "DELETE FROM SE2_Good WHERE advertID = :advertID";
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

        /// <summary>
        /// checked of een advert al bestaat met dezelfde title
        /// returned true wanneer er een advert met dezelfde title is gevonden
        /// returned false indien dit niet zo is
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool CheckAdvert(string title)
        {
            bool result = false;

            try
            {
                OracleCommand oracleCommand;
                OracleDataReader oracleDataReader;

                OracleConnection.Open();
                oracleCommand = OracleConnection.CreateCommand();

                oracleCommand.CommandText = "SELECT title FROM SE2_ADVERT WHERE title = :title";
                oracleCommand.Parameters.Add(new OracleParameter("title", title));

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

        //get alle adverts en returned een List met deze adverts
        public List<Advert> GetAllAdverts()
        {
            List<Advert> adverts = new List<Advert>();

            foreach (Good good in GetAllGoods())
            {
                adverts.Add(good);
            }

            foreach (Service service in GetAllServices())
            {
                adverts.Add(service);
            }

            return adverts;
        }

        /// <summary>
        /// returned een List met alle Services
        /// </summary>
        /// <returns></returns>
        private List<Service> GetAllServices()
        {
            List<Service> services = new List<Service>();

            try
            {
                OracleCommand oracleCommand;
                OracleDataReader oracleDataReader;

                OracleConnection.Open();
                oracleCommand = OracleConnection.CreateCommand();

                oracleCommand.CommandText =
                    "SELECT A.advertID, A.title, A.creationDate, A.views, A.serviceOrGood, A.userID, A.categoryID, S.experience, S.employees, S.companyType FROM SE2_Advert A, SE2_Service S WHERE A.advertID = S.advertID";

                oracleDataReader = oracleCommand.ExecuteReader();

                if (oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        int advertID = Convert.ToInt32(oracleDataReader["A.advertID"]);
                        string title = Convert.ToString(oracleDataReader["A.title"]);
                        DateTime creationDate = Convert.ToDateTime(oracleDataReader["A.creationDate"]);
                        int views = Convert.ToInt32(oracleDataReader["A.views"]);
                        bool isService = Convert.ToInt32(oracleDataReader["A.serviceOrGood"]) == 1;
                        int userID = Convert.ToInt32(oracleDataReader["A.userID"]);
                        int categoryID = Convert.ToInt32(oracleDataReader["A.categoryID"]);
                        string experience = Convert.ToString(oracleDataReader["S.experience"]);
                        string employees = Convert.ToString(oracleDataReader["S.employees"]);
                        string companyType = Convert.ToString(oracleDataReader["S.companyType"]);

                        services.Add(new Service(advertID, title, creationDate, views, isService, userID, categoryID,
                            experience, employees, companyType));
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
            return services;
        }

        /// <summary>
        /// returned een List met alle Goods
        /// </summary>
        /// <returns></returns>
        public List<Good> GetAllGoods()
        {
            List<Good> goods = new List<Good>();

            try
            {
                OracleCommand oracleCommand;
                OracleDataReader oracleDataReader;

                OracleConnection.Open();
                oracleCommand = OracleConnection.CreateCommand();

                oracleCommand.CommandText =
                    "SELECT A.advertID, A.title, A.creationDate, A.views, A.serviceOrGood, A.userID, A.categoryID, G.condition FROM SE2_Advert A, SE2_Good G WHERE A.advertID = G.advertID";

                oracleDataReader = oracleCommand.ExecuteReader();

                if (oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        int advertID = Convert.ToInt32(oracleDataReader["A.advertID"]);
                        string title = Convert.ToString(oracleDataReader["A.title"]);
                        DateTime creationDate = Convert.ToDateTime(oracleDataReader["A.creationDate"]);
                        int views = Convert.ToInt32(oracleDataReader["A.views"]);
                        bool isService = Convert.ToInt32(oracleDataReader["A.serviceOrGood"]) == 1;
                        int userID = Convert.ToInt32(oracleDataReader["A.userID"]);
                        int categoryID = Convert.ToInt32(oracleDataReader["A.categoryID"]);
                        string condition = Convert.ToString(oracleDataReader["G.condition"]);

                        goods.Add(new Good(advertID, title, creationDate, views, isService, userID, categoryID,
                            condition));
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

            return goods;
        }
    }
}