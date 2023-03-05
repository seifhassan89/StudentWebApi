using Models;

namespace Services
{
    public interface IStudentCourseService
    {
        public bool DeleteStudentCourse(int courseId, int studentId);
        public StudentCourse AddStudentCourse(int courseId, int studentId);
        public void SaveChanges();

    }
}
