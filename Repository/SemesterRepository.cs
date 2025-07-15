using MySqlConnector;
using NotenManager.Model;
using System.Data;
using Dapper;


namespace NotenManager.Repository
{
    public class SemesterRepository
    {
        private String connection;
        private IDbConnection dbConnection => new MySqlConnection(connection); //Property to get the database connection
                                                    
        // Constructor to initialize the connection string
        public SemesterRepository(string connectionString)
        {
            connection = connectionString;
        }


        // read Methode to Get all Semesters
        public IEnumerable<Semester> GetAll()
        {
            using (var db = dbConnection)
            {
                db.Open();
                var result = db.Query<Semester>("SELECT * FROM Semester");
                return result;
            }
        }
        // Create a Semester
        public void Create(Semester semester)
        {
            using (var db = dbConnection)
            {
                db.Open(); 
                db.Execute("INSERT INTO Semester (SemesterNumber) VALUES (@SemesterNumber)", semester);
            }
        }
        // Update the Semester number 
        public void Update(int Id, int SemesterNumber)
        {
            using (var db = dbConnection)
            {
                db.Open();
                db.Execute("UPDATE Semester SET SemesterNumber = @SemesterNumber WHERE id = @Id", new {Id = Id, SemesterNumber = SemesterNumber });
            }   
        }

        // Delete a Semester 
        public void Delete(int Id)
        {
            using (var db = dbConnection)
            {
                db.Open();
                db.Execute("DELETE FROM Semester WHERE Id = @Id", new { Id });
            }
        }

    }
}
