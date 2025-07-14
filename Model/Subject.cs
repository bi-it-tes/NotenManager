namespace NotenManager.Model
{
    public class Subject
    {
       public int Id { get; set; }
       public string Name { get; set; }

       public List<Grade> Grades { get; set; } = new();
       public int SemesterId { get; set; }
        public Semester Semester { get; set; } // Navigation property: Subjects belongs to a Semester
    }
}
