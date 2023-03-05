using Mappers;
using Models;
using Models.DTO;
using Repositories;

namespace Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseMapper _courseMapper;
        private readonly IStudentMapper _studentMapper;
        public CourseService(ICourseRepository courseRepository, ICourseMapper courseMapper, IStudentMapper studentMapper)
        {
            _courseRepository = courseRepository;
            _studentMapper = studentMapper;
            _courseMapper = courseMapper;
        }

        /// <summary>
        /// get list of courses DTO
        /// </summary>
        /// <returns></returns>
        public List<CourseDTO> GetAll()
        {
            List<CourseDTO> courses = new List<CourseDTO>();
            courses = _courseRepository.GetAll().Select(g => _courseMapper.MapToCourseDTO(g)).ToList();
            return courses;
        }

        /// <summary>
        /// get courseDTO by course Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CourseDTO? GetById(int id)
        {
            Course? course = _courseRepository.GetById(id);
            if (course == null)
            {
                return null;
            }
            CourseDTO courseDTO = _courseMapper.MapToCourseDTO(course);
            return courseDTO;
        }

        /// <summary>
        /// add course to db
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public Course AddCourse(CourseDTO course)
        {
            Course courseEntity = _courseMapper.MapToCourse(course);
            return _courseRepository.AddCourse(courseEntity);
        }

        /// <summary>
        /// get all students in a course
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public List<StudentDTO> GetStudentsByCourseId(int courseId)
        {
            {
                List<StudentDTO> students = new List<StudentDTO>();
                students = _courseRepository.GetStudentsByCourseId(courseId).Select(g => _studentMapper.MapToStudentDTO(g)).ToList();
                return students;
            }
        }


        /// <summary>
        /// delete course 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteCourse(int id)
        {
            Course? course = _courseRepository.GetById(id); ;
            if (course == null)
            {
                return false;
            }
            _courseRepository.DeleteCourse(course);
            return true;

        }

        /// <summary>
        /// edit course data 
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="courseDTO"></param>
        /// <returns></returns>
        public bool EditCourse(int courseId, CourseDTO courseDTO)
        {
            Course courseEntity = _courseMapper.MapToCourse(courseDTO);
            return _courseRepository.EditCourse(courseId, courseEntity);
        }

        /// <summary>
        /// save changes to DB
        /// </summary>
        public void SaveChanges()
        {
            _courseRepository.SaveChanges();
        }

    }
}
