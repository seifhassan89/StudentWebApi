using Models.DTO;
using Models;

namespace Mappers
{
    public interface ICourseMapper
    {
        public Course MapToCourse(CourseDTO courseDTO);
        public CourseDTO MapToCourseDTO(Course course);

    }
}