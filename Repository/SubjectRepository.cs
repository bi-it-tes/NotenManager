using NotenManager.Model;
using System.Data;
using System.Data.Common;
using MySqlConnector;
using Dapper;

namespace NotenManager.Repository
{
    public class SubjectRepository
    {
        private String connection;
        private IDbConnection dbConnection => new MySqlConnection(connection); //Property to get the database connection

        // Constructor to initialize the connection string
        public SubjectRepository(string connectionString)
        {
            connection = connectionString;
        }

        // read Methode to Get all Subjects
        public IEnumerable<SubjectModel> GetAll()
        {
            using (var db = dbConnection)
            {
                db.Open();
                var result = db.Query<SubjectModel>("SELECT * FROM Subject");
                return result;
            }
        }
        // Create a Subject
        public async Task Create(SubjectModel subject)
        {
            using var db = dbConnection;
            db.Open();
            await db.ExecuteAsync("INSERT INTO Subject (Name, SemesterId) VALUES (@Name, @SemesterId)", subject);
            
        }
        // Update the Subject Name  
        public void Update(int Id, string Name)
        {
            using (var db = dbConnection)
            {
                db.Open();
                db.Execute("UPDATE Subject SET Name = @Name WHERE id = @Id", new { Id = Id, Name = Name });
            }
        }

        // Delete a Subject 
        public void Delete(int Id)
        {
            using (var db = dbConnection)
            {
                db.Open();
                db.Execute("DELETE FROM Subject WHERE Id = @Id", new { Id });
            }
        }
    }
}