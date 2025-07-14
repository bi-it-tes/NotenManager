namespace NotenManager.Model
{
    public class Semester
    {
        public int Id { get; set; }
        public int SemesterNumber { get; set; }
        // Navigation property: A Semester has many Subjects
        public List<Subject> Subjects { get; set; } = new();
    }
}
