using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace SE2___Individuele_Opdracht
{
    public abstract class DbConnection
    {
        public DbConnection()
        {
            throw new System.NotImplementedException();
        }
    
        public OracleConnection Connection
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string ConnectionString
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void OpenConnection()
        {
            throw new System.NotImplementedException();
        }

        public void CloseConnection()
        {
            throw new System.NotImplementedException();
        }
    }
}
