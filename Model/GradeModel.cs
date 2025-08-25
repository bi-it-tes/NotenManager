namespace NotenManager.Model
{
    public class GradeModel
    {
        public int Id { get; set; }
        public double Weighting { get; set; }  
        public double MaxPoints { get; set; }
        public double AchivedPoints { get; set; }
        public double Grade { get; set; }
        public DateTime Date { get; set; }
        public string? Comment { get; set; } 
        public int SubjectId { get; set; }

    }
}
