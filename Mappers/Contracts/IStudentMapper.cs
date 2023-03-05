using Models.DTO;
using Models;

namespace Mappers
{
    public interface IStudentMapper
    {
        public Student MapToStudent(StudentDTO studentDTO);
        public StudentDTO MapToStudentDTO(Student student);

    }
}