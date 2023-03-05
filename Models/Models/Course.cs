namespace Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }

        public Course()
        {
            StudentCourses = new List<StudentCourse>();
        }
    }
}