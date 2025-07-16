namespace NotenManager.Model
{
    public class SubjectModel
    {
       public int Id { get; set; }
       public string Name { get; set; }

       public List<GradeModel> Grades { get; set; } = new();
       public int SemesterId { get; set; }
        public SemesterModel Semester { get; set; } // Navigation property: Subjects belongs to a Semester
    }
}
