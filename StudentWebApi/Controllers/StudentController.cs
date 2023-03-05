using Mappers;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Services;

namespace StudentWebApi.Controllers
{
    [ApiController]
    [Route("Student")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IStudentMapper _studentMapper;

        public StudentController(IStudentService studentService, IStudentMapper studentMapper)
        {
            _studentService = studentService;
            _studentMapper = studentMapper;
        }

        /// <summary>
        /// get student list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetStudents()
        {
            List<StudentDTO> result = _studentService.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// get student by id
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet("{studentId}")]
        public ActionResult GetStudentById([FromRoute] int studentId)
        {
            StudentDTO? student = _studentService.GetById(studentId);
            return student == null ? NotFound() : Ok(student);
        }

        /// <summary>to Db
        /// add student 
        /// </summary>
        /// <param name="studentDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddStudent([FromBody] StudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please Add Student");
            }
            else
            {
                try
                {
                    Student AddStudent = _studentService.AddStudent(studentDTO);
                    _studentService.SaveChanges();
                    StudentDTO studentDTOResult = _studentMapper.MapToStudentDTO(AddStudent);
                    return Ok(studentDTOResult);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        }

        /// <summary>
        /// edit student data in db
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="studentDTO"></param>
        /// <returns></returns>
        [HttpPut("{studentId}")]
        public ActionResult EditStudent([FromRoute] int studentId, [FromBody] StudentDTO studentDTO)
        {

            bool isEdited = _studentService.EditStudent(studentId, studentDTO);
            if (!isEdited)
            {
                return NotFound("Student Not Found!!!!!!");
            }

            _studentService.SaveChanges();
            return Ok(studentDTO);
        }

        /// <summary>
        /// delete student from db
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>

        [HttpDelete("{studentId}")]
        public ActionResult DeleteStudent([FromRoute] int studentId)
        {
            bool isDeleted = _studentService.DeleteStudent(studentId);
            if (!isDeleted)
            {
                return NotFound("Student Not Found!!!!!!");
            }
            _studentService.SaveChanges();
            return Ok("Student Deleted Successfully");
        }

        /// <summary>
        /// get all courses for a student
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        [HttpGet("StudentsByCourse/{courseId}")]
        public ActionResult CoursesByCourseId([FromRoute] int studentId)
        {
            List<CourseDTO> courses = _studentService.GetCoursesByStudentId(studentId);
            return Ok(courses);
        }
    }
}
