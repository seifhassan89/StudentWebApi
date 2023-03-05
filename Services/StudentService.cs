using Mappers;
using Models;
using Models.DTO;
using Repositories;

namespace Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentMapper _studentMapper;
        private readonly ICourseMapper _courseMapper;
        public StudentService(IStudentRepository studentRepository, IStudentMapper studentMapper, ICourseMapper courseMapper)
        {
            _studentRepository = studentRepository;
            _studentMapper = studentMapper;
            _courseMapper = courseMapper;
        }

        /// <summary>
        /// get list of students DTO
        /// </summary>
        /// <returns></returns>
        public List<StudentDTO> GetAll()
        {
            List<StudentDTO> students = new List<StudentDTO>();
            students = _studentRepository.GetAll().Select(g => _studentMapper.MapToStudentDTO(g)).ToList();
            return students;
        }

        /// <summary>
        /// get studentDTO by student Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentDTO? GetById(int id)
        {
            Student? student = _studentRepository.GetById(id);
            if (student == null)
            {
                return null;
            }
            StudentDTO studentDTO = _studentMapper.MapToStudentDTO(student);
            return studentDTO;
        }

        /// <summary>
        /// add student to db
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student AddStudent(StudentDTO student)
        {
            Student studentEntity = _studentMapper.MapToStudent(student);
            return _studentRepository.AddStudent(studentEntity);
        }

        /// <summary>
        /// delete student 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteStudent(int id)
        {
            Student? student = _studentRepository.GetById(id); ;
            if (student == null)
            {
                return false;
            }
            _studentRepository.DeleteStudent(student);
            return true;

        }

        /// <summary>
        /// edit student data 
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="studentDTO"></param>
        /// <returns></returns>
        public bool EditStudent(int studentId, StudentDTO studentDTO)
        {
            Student studentEntity = _studentMapper.MapToStudent(studentDTO);
            return _studentRepository.EditStudent(studentId, studentEntity);
        }
        /// <summary>
        ///  get student courses by student ID 
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public List<CourseDTO> GetCoursesByStudentId(int studentId)
        {
            {
                return _studentRepository.GetCoursesByStudentId(studentId).Select(g => _courseMapper.MapToCourseDTO(g)).ToList();
            }
        }
        /// <summary>
        /// save changes to DB
        /// </summary>
        public void SaveChanges()
        {
            _studentRepository.SaveChanges();
        }

    }
}
