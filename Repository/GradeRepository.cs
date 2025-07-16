using NotenManager.Model;
using System.Data;
using MySqlConnector;
using Dapper;

namespace NotenManager.Repository
{
    public class GradeRepository
    {
        private String connection;
        private IDbConnection dbConnection => new MySqlConnection(connection); //Property to get the database connection

        // Constructor to initialize the connection string
        public GradeRepository(string ConnectionString)
        {
            connection = ConnectionString;
        }

        // read Methode to Get all Grades
        public IEnumerable<GradeModel> GetAll()
        {
            using (var db = dbConnection)
            {
                db.Open();
                var result = db.Query<GradeModel>("SELECT * FROM Grade");
                return result;
            }
        }
        // Create a Subject
        public void Create(GradeModel grade)
        {
            using (var db = dbConnection)
            {
                db.Open();
                db.Execute("INSERT INTO Grade (Name, Weighting, MaxPoints, AchivedPoints, Date, Comment) VALUES (@Name, @Weighting, @MaxPoints, @AchivedPoints, @Date, @Comment)", grade);
            }
        }
        // Update the Subject Name  
        public void Update(int Id, double Weighting, int MaxPoints, int AchivedPoints, string Comment)
        {
            using (var db = dbConnection)
            {
                db.Open();
                db.Execute("UPDATE Grade SET Weighting = @Weighting, MaxPoints = @MaxPoints, AchivedPoints = @AchivedPoints, Comment = @Comment WHERE id = @Id",
                    new { Id = Id, Weighting = Weighting, MaxPoints = MaxPoints, AchivedPoints = AchivedPoints, Comment = Comment });
            }
        }

        // Delete a Subject 
        public void Delete(int Id)
        {
            using (var db = dbConnection)
            {
                db.Open();
                db.Execute("DELETE FROM Grade WHERE Id = @Id", new { Id });
            }
        }
    }
}
