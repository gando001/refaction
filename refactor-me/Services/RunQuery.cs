using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace refactor_me.Services
{
    public class RunQuery
    {
        public SqlCommand Command { get; private set; }
        private String ConnectionString { get; set; }
        
        public RunQuery(SqlCommand command, String connection = null)
        {
            this.Command = command;
            this.ConnectionString = connection;
        }

        public SqlDataReader RetrieveRows()
        {
            SetupConnection();
			return Command.ExecuteReader();
        }

        public void Execute()
        {
            SetupConnection();
            Command.ExecuteNonQuery();
        }

        private void SetupConnection()
        {
			var connection = GetConnection();
			Command.Connection = connection;

			connection.Open();
        }

        private SqlConnection GetConnection()
        {
            if (ConnectionString == null)
            {
                ConnectionString = (ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString).Replace("{DataDirectory}", HttpContext.Current.Server.MapPath("~/App_Data"));
            }

			return new SqlConnection(ConnectionString);
        }
    }
}
