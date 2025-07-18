namespace NotenManager.Model
{
    public class GradeModel
    {
        public int Id { get; set; }
        public double? Weighting { get; set; }  
        public int MaxPoints { get; set; }
        public int AchivedPoints { get; set; }
        public double Grade { get; set; }
        public DateTime Date { get; set; }
        public string? Comment { get; set; } 
        public int SubjectId { get; set; }

    }
}
