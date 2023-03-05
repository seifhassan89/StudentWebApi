using Data;
using Models;

namespace Repositories
{
    public interface IStudentCourseRepository : IBaseRepository
    {
        StudentCourse? GetStudentCourse(int studentId, int courseId);
        public StudentCourse AddStudentCourse(StudentCourse studentStudentCourse);
        public void DeleteStudentCourse(StudentCourse studentStudentCourse);
    }
}
