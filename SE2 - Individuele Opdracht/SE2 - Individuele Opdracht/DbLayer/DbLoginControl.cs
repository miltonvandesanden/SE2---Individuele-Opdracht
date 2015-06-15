using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;

namespace SE2___Individuele_Opdracht
{
    /// <summary>
    /// deze class vormt de verbinding tussen de LoginControl class en de database.
    /// </summary>
    public class DbLoginControl : DbConnection
    {
        /// <summary>
        /// returned true wanneer de ingevulde inloggegevens overeen komen met een bestaand account uit de database,
        /// returned false wanneer dit niet zo is
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string username, string password)
        {
            return CheckUser(username, password);
        }

        /// <summary>
        /// checked met behulp van de username en het password of een gebruiker in de database voorkomt.
        /// returned true in dit zo is en returned false indien dit niet zo is
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool CheckUser(string username, string password)
        {
            bool result = false;

            try
            {
                OracleCommand oracleCommand;
                OracleDataReader oracleDataReader;

                OracleConnection.Open();
                oracleCommand = OracleConnection.CreateCommand();

                oracleCommand.CommandText =
                    "SELECT userName, userPassword FROM SE2_User WHERE userName = :username AND userPassword = :password";
                oracleCommand.Parameters.Add(new OracleParameter("username", username));
                oracleCommand.Parameters.Add(new OracleParameter("password", password));

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

        public void Logout()
        {
            throw new System.NotImplementedException();
        }
    }
}
