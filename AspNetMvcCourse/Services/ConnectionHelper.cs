using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AspNetMvcCourse.Services
{
    public static class ConnectionHelper
    {
        public static IDbConnection GetConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AspNetMvcDbContext"].ToString();
            return new SqlConnection(connectionString);
        }

        public static IDbConnection GetConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

    }
}