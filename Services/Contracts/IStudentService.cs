using Models;
using Models.DTO;

namespace Services
{
    public interface IStudentService
    {
        public List<StudentDTO> GetAll();
        public StudentDTO? GetById(int id);
        public bool EditStudent(int studentId, StudentDTO studentDTO);
        public bool DeleteStudent(int id);
        public Student AddStudent(StudentDTO student);
        public List<CourseDTO> GetCoursesByStudentId(int studentId);
        public void SaveChanges();

    }
}
