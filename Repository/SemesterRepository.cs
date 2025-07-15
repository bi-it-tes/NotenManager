using MySqlConnector;

namespace NotenManager.Repository
{
    public class SemesterRepository
    {
        private String connection;
        private IDbConnection dbConnection => new MySQLConnection(connection); //Property to get the database connection

        // Constructor to initialize the connection string
        public SemesterRepository(string connectionString)
        {
            connection = connectionString;
        }

    }
}
