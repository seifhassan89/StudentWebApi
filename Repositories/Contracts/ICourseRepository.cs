using Data;
using Models;

namespace Repositories
{
    public interface ICourseRepository : IBaseRepository
    {
        public List<Course> GetAll();
        public Course? GetById(int id);

        public Course AddCourse(Course course);
        bool EditCourse(int courseId, Course course);
        public void DeleteCourse(Course course);
        List<Student> GetStudentsByCourseId(int courseId);
    }
}
