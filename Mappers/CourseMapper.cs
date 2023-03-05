using Models;
using Models.DTO;

namespace Mappers
{
    public class CourseMapper : ICourseMapper
    {
        /// <summary>
        /// map CourseDTO to Course
        /// </summary>
        /// <param name="courseDTO"></param>
        /// <returns></returns>
        public Course MapToCourse(CourseDTO courseDTO)
        {
            Course course = new Course();
            course.CourseID = courseDTO.CourseID;
            course.Name = courseDTO.Name;
            course.Description = courseDTO.Description;
            course.Credits = courseDTO.Credits;
            course.DepartmentID = courseDTO.DepartmentID;

            return course;

        }

        /// <summary>
        /// map Course to CourseDTO
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public CourseDTO MapToCourseDTO(Course course)
        {
            CourseDTO courseDTO = new CourseDTO();
            courseDTO.CourseID = course.CourseID;
            courseDTO.Name = course.Name;
            courseDTO.Description = course.Description;
            courseDTO.Credits = course.Credits;
            courseDTO.DepartmentID = course.DepartmentID;
            courseDTO.DepartmentName = course.Department != null ? course.Department.Name : "";

            return courseDTO;

        }
    }
}