using System.Data.SqlClient;

namespace DirectDbAccess.Data
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

        public SqlDataReader GetData(SqlConnection connection, string query)
        {
            var command = new SqlCommand(query, connection);
            return command.ExecuteReader();
        }

        public void ExecuteCommand(SqlConnection connection, string query)
        {
            var command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            if (connection != null)
                connection.Close();
        }
    }
}
