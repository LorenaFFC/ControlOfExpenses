using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControlOfExpenses.ADO
{
    public class ConnectionManager
    {
        public static SqlConnection GetSqlConnection()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connStrig;
            connStrig = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];
            var SQLConnection = new SqlConnection(connStrig.ToString());
            SQLConnection.Open();
            return SQLConnection;
        }
        public static SqlConnection CloseConnection()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connStrig;
            connStrig = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];
            var SQLConnection = new SqlConnection(connStrig.ToString());
            SQLConnection.Close();
            return SQLConnection;
        }

        public static DataTable ExecuteQuery(string QueryCliente)
        {
            var connection = GetSqlConnection();
            SqlDataAdapter sqlData = new SqlDataAdapter(QueryCliente, connection);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            return dtbl;
        }

        public static void ExecuteNonQuery(string CommandText, params SqlParameter[] commandParameters)
        {
            var conection = GetSqlConnection();
            SqlCommand cmd = new SqlCommand(CommandText, conection);

            //  cmd.Connection = GetSqlConnection();*/
            cmd.Parameters.AddRange(commandParameters);
            cmd.ExecuteNonQuery();
        }


    }
}
