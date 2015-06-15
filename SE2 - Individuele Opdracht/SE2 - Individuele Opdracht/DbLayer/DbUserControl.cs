using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Oracle.DataAccess.Client;

namespace SE2___Individuele_Opdracht
{
    public class DbUserControl : DbConnection
    {
        public bool CheckPostalcode(string postalcode)
        {
            bool result = false;

            try
            {
                OracleCommand oracleCommand;
                OracleDataReader oracleDataReader;

                OracleConnection.Open();
                oracleCommand = OracleConnection.CreateCommand();

                oracleCommand.CommandText = "SELECT postalcode FROM SE2_Postalcode WHERE postalcode = :postalcode";
                oracleCommand.Parameters.Add(new OracleParameter("postalcode", postalcode));

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
        public void CreatePostalcode(string postalcode)
        {
            try
            {
                OracleCommand oracleCommand;

                OracleConnection.Open();
                oracleCommand = OracleConnection.CreateCommand();

                oracleCommand.CommandText = "INSERT INTO SE2_User (postalcode) VALUES(:postalcode)";
                oracleCommand.Parameters.Add(new OracleParameter("postalcode", postalcode));

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

        public bool CheckUser(string username)
        {
            bool result = false;

            try
            {
                OracleCommand oracleCommand;
                OracleDataReader oracleDataReader;

                OracleConnection.Open();

                oracleCommand = OracleConnection.CreateCommand();

                oracleCommand.CommandText = "SELECT userName FROM SE2_User WHERE userName = :username";
                oracleCommand.Parameters.Add(new OracleParameter("username", username));

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
        public void CreateUser(string userName, string userPassword, string email, int phone, string postalcode)
        {
            if (!CheckUser(userName))
            {
                if (!CheckPostalcode(postalcode))
                {
                    CreatePostalcode(postalcode);
                }

                try
                {
                    OracleCommand oracleCommand;

                    OracleConnection.Open();
                    oracleCommand = OracleConnection.CreateCommand();

                    oracleCommand.CommandText =
                        "INSERT INTO SE2_User (userName, userPassword, email, phoneNumber, postalcode) VALUES(:userName, :userPassword, :email, :phoneNumber, :postalcode)";
                    oracleCommand.Parameters.Add(new OracleParameter("userName", userName));
                    oracleCommand.Parameters.Add(new OracleParameter("userPassword", userPassword));
                    oracleCommand.Parameters.Add(new OracleParameter("email", email));
                    oracleCommand.Parameters.Add(new OracleParameter("phoneNumber", phone));
                    oracleCommand.Parameters.Add(new OracleParameter("postalcode", postalcode));
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

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            try
            {
                OracleCommand oracleCommand;
                OracleDataReader oracleDataReader;

                OracleConnection.Open();

                oracleCommand = OracleConnection.CreateCommand();

                oracleCommand.CommandText =
                    "SELECT userID, userName, userPassword, email, phoneNumber, postalcodeID emailPref, paymentPref, receiptPref FROM SE2_User";

                oracleDataReader = oracleCommand.ExecuteReader();

                if (oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        int userID = Convert.ToInt32(oracleDataReader["userID"]);
                        string userName = Convert.ToString(oracleDataReader["userName"]);
                        string userPassword = Convert.ToString(oracleDataReader["userPassword"]);
                        string email = Convert.ToString(oracleDataReader["email"]);
                        int phone = Convert.ToInt32(oracleDataReader["phoneNumber"]);
                        int postalcodeID = Convert.ToInt32(oracleDataReader["postalcodeID"]);
                        bool emailPref = Convert.ToInt32(oracleDataReader["emailPref"]) == 1;
                        bool paymentPref = Convert.ToInt32(oracleDataReader["paymentPref"]) == 1;
                        bool receiptPref = Convert.ToInt32(oracleDataReader["emailPref"]) == 1;

                        users.Add(new User(userID, userName, userPassword, email, phone, postalcodeID, emailPref,
                            paymentPref, receiptPref, GetAllAdvertIDOfUser(userID)));
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

            return users;
        }

        public List<int> GetAllAdvertIDOfUser(int userID)
        {
            List<int> advertID = new List<int>();

            try
            {
                OracleCommand oracleCommand;
                OracleDataReader oracleDataReader;

                OracleConnection.Open();
                oracleCommand = OracleConnection.CreateCommand();

                oracleCommand.CommandText = "Select advertID FROM SE2_Advert WHERE userID = :userID";
                oracleCommand.Parameters.Add(new OracleParameter("userID", userID));

                oracleDataReader = oracleCommand.ExecuteReader();

                if (oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        advertID.Add(Convert.ToInt32(oracleDataReader["advertID"]));
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

            return advertID;
        }
    }
}
