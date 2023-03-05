namespace Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int GenderID { get; set; }
        public Gender Gender { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
        public Student()
        {
            StudentCourses = new List<StudentCourse>();
        }
    }
}