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
        public bool CheckPostalcode(string postalcode)
        {
            bool result = false;

            try
            {
                OracleConnection.Open();

                OracleCommand oracleCommand = OracleConnection.CreateCommand();
                OracleDataReader oracleDataReader;

                oracleCommand.CommandText = "SELECT postalcode FROM SE2_Postalcode WHERE postalcode = :postalcode";
                oracleCommand.Parameters.Add("postalcode", postalcode);

                oracleDataReader = oracleCommand.ExecuteReader();

                if (oracleDataReader.HasRows)
                {
                    result = true;
                }

                OracleConnection.Close();
            }
            catch (Exception exception)
            {
                
                throw exception;
            }

            return result;
        }
        public void CreatePostalcode(string postalcode)
        {
            try
            {
                OracleConnection.Open();

                OracleCommand oracleCommand = OracleConnection.CreateCommand();

                oracleCommand.CommandText = "INSERT INTO SE2_User (postalcode) VALUES(:postalcode)";
                oracleCommand.Parameters.Add("postalcode", postalcode);

                oracleCommand.ExecuteNonQuery();

                OracleConnection.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool CheckUser(string username)
        {
            bool result = false;

            try
            {
                OracleConnection.Open();

                OracleCommand oracleCommand = OracleConnection.CreateCommand();
                OracleDataReader oracleDataReader;

                oracleCommand.CommandText = "SELECT userName FROM SE2_User WHERE userName = :username";
                oracleCommand.Parameters.Add("username", username);

                oracleDataReader = oracleCommand.ExecuteReader();

                if (oracleDataReader.HasRows)
                {
                    result = true;
                }

                OracleConnection.Close();
            }
            catch (Exception exception)
            {
                throw exception;
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
                    OracleConnection.Open();

                    OracleCommand oracleCommand = OracleConnection.CreateCommand();

                    oracleCommand.CommandText = "INSERT INTO SE2_User (userName, userPassword, email, phoneNumber, postalcode) VALUES(:userName, :userPassword, :email, :phoneNumber, :postalcode)";
                    oracleCommand.Parameters.Add("userName", userName);
                    oracleCommand.Parameters.Add("userPassword", userPassword);
                    oracleCommand.Parameters.Add("email", email);
                    oracleCommand.Parameters.Add("phoneNumber", phone);
                    oracleCommand.Parameters.Add("postalcode", postalcode);

                    OracleConnection.Close();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            try
            {
                OracleConnection.Open();

                OracleCommand oracleCommand = OracleConnection.CreateCommand();
                OracleDataReader oracleDataReader;

                oracleCommand.CommandText = "SELECT userID, userName, userPassword, email, phoneNumber, postalcodeID emailPref, paymentPref, receiptPref FROM SE2_User";

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
                        int postalcode = Convert.ToInt32(oracleDataReader["postalcode"]);
                        bool emailPref = Convert.ToInt32(oracleDataReader["emailPref"]) == 1;
                        bool paymentPref = Convert.ToInt32(oracleDataReader["paymentPref"]) == 1;
                        bool receiptPref = Convert.ToInt32(oracleDataReader["emailPref"]) == 1;
                        
                        users.Add(new User(userID, userName, userPassword, email, phone, postalcode, emailPref, paymentPref, receiptPref, GetAllAdvertIDOfUser(userID)));
                    }
                }

                OracleConnection.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return users;
        }

        public List<int> GetAllAdvertIDOfUser(int userID)
        {
            List<int> advertID = new List<int>();

            try
            {
                OracleConnection.Open();

                OracleCommand oracleCommand = OracleConnection.CreateCommand();
                OracleDataReader oracleDataReader;

                oracleCommand.CommandText = "Select advertID FROM SE2_Advert WHERE userID = :userID";
                oracleCommand.Parameters.Add("userID", userID);

                oracleDataReader = oracleCommand.ExecuteReader();

                if (oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        advertID.Add(Convert.ToInt32(oracleDataReader["advertID"]));
                    }
                }

                OracleConnection.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return advertID;
        }
    }
}
