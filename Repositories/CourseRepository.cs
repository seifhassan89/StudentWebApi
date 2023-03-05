using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;

namespace Repositories
{
    public class CourseRepository : BaseRepository, ICourseRepository
    {
        private StudentDB _StudentDB;
        public CourseRepository(StudentDB studentDB) : base(studentDB)
        {
            _StudentDB = studentDB;
        }

        /// <summary>
        /// get all courses
        /// </summary>
        /// <returns></returns>
        public List<Course> GetAll()
        {
            return _StudentDB.Courses.ToList();
        }

        /// <summary>
        /// get course by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Course? GetById(int id)
        {
            return _StudentDB.Courses.FirstOrDefault(g => g.CourseID == id);
        }
        /// <summary>
        /// delete course
        /// </summary>
        /// <param name="course"></param>
        public void DeleteCourse(Course course)
        {
            _StudentDB.Remove(course);
        }

        /// <summary>
        /// edit course data
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="course"></param>
        public bool EditCourse(int courseId, Course course)
        {
            Course? existingEntity = _StudentDB.Courses.Find(courseId);
            if (existingEntity == null)
            {
                return false;
            }
            else
            {
                _StudentDB.Entry(existingEntity).State = EntityState.Detached;
            }
            _StudentDB.Attach(course);
            _StudentDB.Entry(course).State = EntityState.Modified;
            return true;
        }


        /// <summary>
        /// add course to database
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public Course AddCourse(Course course)
        {
            EntityEntry<Course> x = _StudentDB.Courses.Add(course);
            return x.Entity;

        }
        /// <summary>
        /// get all students in a course
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public List<Student> GetStudentsByCourseId(int courseId)
        {
            List<Student> students = new List<Student>();
            Course? course = _StudentDB.Courses
                .Include(x => x.StudentCourses)
                .ThenInclude(x => x.Student).FirstOrDefault(x => x.CourseID == courseId);
            if (course != null)
            {
                students = course.StudentCourses.Select(x => x.Student).ToList();
            }
            return students;
        }
    }
}
