using Models;
using Models.DTO;

namespace Mappers
{
    public class StudentMapper : IStudentMapper
    {
        /// <summary>
        /// map StudentDTO to Student
        /// </summary>
        /// <param name="studentDTO"></param>
        /// <returns></returns>
        public Student MapToStudent(StudentDTO studentDTO)
        {
            Student student = new Student();
            student.StudentID = studentDTO.StudentID;
            student.FullName = studentDTO.FullName;
            student.Phone = studentDTO.Phone;
            student.Email = studentDTO.Email;
            student.BirthDate = studentDTO.BirthDate;
            student.GenderID = studentDTO.GenderID;
            return student;

        }

        /// <summary>
        /// map Student to StudentDTO
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public StudentDTO MapToStudentDTO(Student student)
        {
            StudentDTO studentDTO = new StudentDTO();
            studentDTO.StudentID = student.StudentID;
            studentDTO.FullName = student.FullName;
            studentDTO.Phone = student.Phone;
            studentDTO.Email = student.Email;
            studentDTO.BirthDate = student.BirthDate;
            studentDTO.GenderID = student.GenderID;
            studentDTO.GenderName = student.Gender != null ? student.Gender.Name : "";
            return studentDTO;

        }
    }
}