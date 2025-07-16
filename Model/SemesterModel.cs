namespace NotenManager.Model
{
    public class SemesterModel
    {
        public int Id { get; set; }
        public int SemesterNumber { get; set; }
        // Navigation property: A Semester has many Subjects
        public List<SubjectModel> Subjects { get; set; } = new();
    }
}
