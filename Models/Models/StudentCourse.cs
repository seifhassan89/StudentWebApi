namespace Models
{
    public class StudentCourse
    {
        public int StudentCourseID { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }

        public StudentCourse()
        {

        }
    }
}