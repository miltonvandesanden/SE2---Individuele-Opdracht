using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using Oracle.DataAccess.Client;

namespace SE2___Individuele_Opdracht
{
    public abstract class DbConnection
    {
        private OracleConnection oracleConnection;
        private string connectionString = "DATA SOURCE=//localhost:1521/xe;PASSWORD=SE2;USER ID=SE2";
        public OracleConnection OracleConnection { get { return oracleConnection; }}

        public DbConnection()
        {
            try
            {
                oracleConnection = new OracleConnection(connectionString);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
