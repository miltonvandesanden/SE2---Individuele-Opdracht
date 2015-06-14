using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;

namespace SE2___Individuele_Opdracht
{
    public class DbLoginControl : DbConnection
    {
    
        public bool Login(string username, string password)
        {
            bool result = false;

            try
            {
                OracleCommand oracleCommand = OracleConnection.CreateCommand();
                OracleDataReader oracleDataReader = oracleCommand.ExecuteReader();

                oracleCommand.CommandText = "SELECT userName, userPassword FROM SE2_User WHERE userName = :username AND userPassword = :password";
                oracleCommand.Parameters.Add("username", username);
                oracleCommand.Parameters.Add("password", password);

                OracleConnection.Open();

                if (oracleDataReader.HasRows)
                {
                    result = true;
                }
            }
            catch (Exception exception)
            {
                
                throw exception;
            }

            return result;
        }

        public void Logout()
        {
            throw new System.NotImplementedException();
        }
    }
}
