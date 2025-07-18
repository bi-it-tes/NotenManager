using Dapper;
using MySqlConnector;
using NotenManager.Components.Pages;
using NotenManager.Model;
using System.Data;

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
        public IEnumerable<GradeModel> GetBySubject(int SubjectId)
        {
            using (var db = dbConnection)
            {
                db.Open();
                var result = db.Query<GradeModel>("SELECT * FROM Grade WHERE SubjectId = @SubjectId", new { SubjectId });
                return result;
            }
        }
        // Create a Subject
        public async Task Create(GradeModel grade)
        {
            using (var db = dbConnection)
            {
                db.Open();  
                await db.ExecuteAsync("INSERT INTO Grade (SubjectId, Weighting, MaxPoints, AchivedPoints, Grade, Date, Comment) VALUES (@SubjectId, @Weighting, @MaxPoints, @AchivedPoints, @Grade, @Date, @Comment)", grade);
            }
        }
        // Calculation Function to calculate the Total grade of the Subject
        public double? CalcTotalGrade(int subjectId)
        {
            var grades = GetBySubject(subjectId);

            double weightedSum = 0;
            double totalWeight = 0;

            foreach (var grade in grades)
            {
                if (grade.Weighting > 0)
                {
                    weightedSum += grade.Grade * grade.Weighting;
                    totalWeight += grade.Weighting;
                }
            }
            
            if (totalWeight == 0)
                return null;

            double totalGrade = weightedSum / totalWeight;
            return totalGrade;
           
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
