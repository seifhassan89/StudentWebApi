using Mappers;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Services;

namespace StudentWebApi.Controllers
{
    [ApiController]
    [Route("Course")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IStudentCourseService _studentCourseService;
        private readonly ICourseMapper _courseMapper;

        public CourseController(ICourseService courseService, IStudentCourseService studentCourseService, ICourseMapper courseMapper)
        {
            _studentCourseService = studentCourseService;
            _courseService = courseService;
            _courseMapper = courseMapper;
        }

        /// <summary>
        /// get course list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetCourses()
        {
            List<CourseDTO> result = _courseService.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// get course by id
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        [HttpGet("{courseId}")]
        public ActionResult GetCourseById([FromRoute] int courseId)
        {
            CourseDTO? course = _courseService.GetById(courseId);
            return course == null ? NotFound() : Ok(course);
        }

        /// <summary>to Db
        /// add course 
        /// </summary>
        /// <param name="courseDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCourse([FromBody] CourseDTO courseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please Add Course");
            }
            else
            {
                try
                {
                    Course AddCourse = _courseService.AddCourse(courseDTO);
                    _courseService.SaveChanges();
                    CourseDTO courseDTOResult = _courseMapper.MapToCourseDTO(AddCourse);
                    return Ok(courseDTOResult);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        }

        /// <summary>
        /// edit course data in db
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="courseDTO"></param>
        /// <returns></returns>
        [HttpPut("{courseId}")]
        public ActionResult EditCourse([FromRoute] int courseId, [FromBody] CourseDTO courseDTO)
        {

            bool isEdited = _courseService.EditCourse(courseId, courseDTO);
            if (!isEdited)
            {
                return NotFound("Course Not Found!!!!!!");
            }

            _courseService.SaveChanges();
            return Ok(courseDTO);
        }

        /// <summary>
        /// delete course from db
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>

        [HttpDelete("{courseId}")]
        public ActionResult DeleteCourse([FromRoute] int courseId)
        {
            bool isDeleted = _courseService.DeleteCourse(courseId);
            if (!isDeleted)
            {
                return NotFound("Course Not Found!!!!!!");
            }
            _courseService.SaveChanges();
            return Ok("Course Deleted Successfully");
        }

        [HttpPost("registerStudentCourse/{courseId}/{studentId}")]
        public ActionResult RegisterStudentCourse([FromRoute] int courseId, [FromRoute] int studentId)
        {

            StudentCourse studentCourse = _studentCourseService.AddStudentCourse(courseId, studentId);
            _studentCourseService.SaveChanges();
            return Ok("Student Registered to Course Successfully");
        }

        [HttpDelete("registerStudentCourse/{courseId}/{studentId}")]
        public ActionResult DeleteStudentCourse([FromRoute] int courseId, [FromRoute] int studentId)
        {

            StudentCourse studentCourse = _studentCourseService.AddStudentCourse(courseId, studentId);
            _studentCourseService.SaveChanges();
            return Ok("Student Deleted from Course Successfully");
        }

        /// <summary>
        /// get all students in a course
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        [HttpGet("StudentsByCourse/{courseId}")]
        public ActionResult StudentsByCourseId([FromRoute] int courseId)
        {
            List<StudentDTO> students = _courseService.GetStudentsByCourseId(courseId);
            return Ok(students);
        }
    }
}
