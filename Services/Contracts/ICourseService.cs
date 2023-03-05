using Models;
using Models.DTO;

namespace Services
{
    public interface ICourseService
    {
        public List<CourseDTO> GetAll();
        public CourseDTO? GetById(int id);
        public bool EditCourse(int courseId, CourseDTO courseDTO);
        public bool DeleteCourse(int id);
        public Course AddCourse(CourseDTO course);
        public List<StudentDTO> GetStudentsByCourseId(int courseId);
        public void SaveChanges();

    }
}
