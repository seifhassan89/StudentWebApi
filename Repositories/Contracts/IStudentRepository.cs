using Data;
using Models;

namespace Repositories
{
    public interface IStudentRepository : IBaseRepository
    {
        public List<Student> GetAll();
        public Student? GetById(int id);

        public Student AddStudent(Student student);
        bool EditStudent(int studentId, Student student);
        public void DeleteStudent(Student student);
        public List<Course> GetCoursesByStudentId(int studentId);
    }
}
