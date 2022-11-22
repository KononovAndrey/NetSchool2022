using System.Data.SqlClient;

namespace DapperDbAccess.Data
{
    public class Db : IDisposable
    {
        private const string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=DSRNetSchoolSampleDb;Integrated Security=true;";
        private SqlConnection connection;

        public Db()
        {
        }

        public SqlConnection GetConnection()
        {
            connection = connection ?? new SqlConnection(connectionString);
            connection.Open();

            return connection;
        }

        public void Dispose()
        {
            if (connection != null)
                connection.Close();
        }
    }
}
