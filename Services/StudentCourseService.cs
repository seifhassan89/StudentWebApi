using Models;
using Repositories;

namespace Services
{
    public class StudentCourseService : IStudentCourseService
    {
        private readonly IStudentCourseRepository _studentStudentCourseRepository;
        public StudentCourseService(IStudentCourseRepository studentStudentCourseRepository)
        {
            _studentStudentCourseRepository = studentStudentCourseRepository;
        }

        /// <summary>
        /// add studentStudentCourse to db
        /// </summary>
        /// <param name="studentStudentCourse"></param>
        /// <returns></returns>
        public StudentCourse AddStudentCourse(int courseId, int studentId)
        {
            StudentCourse studentStudentCourseEntity = new StudentCourse()
            {
                CourseID = courseId,
                StudentID = studentId
            };
            return _studentStudentCourseRepository.AddStudentCourse(studentStudentCourseEntity);
        }

        /// <summary>
        /// delete studentStudentCourse 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteStudentCourse(int courseId, int studentId)
        {
            StudentCourse? studentStudentCourse = _studentStudentCourseRepository.GetStudentCourse(studentId, courseId); ;
            if (studentStudentCourse == null)
            {
                return false;
            }
            _studentStudentCourseRepository.DeleteStudentCourse(studentStudentCourse);
            return true;

        }

        /// <summary>
        /// save changes to DB
        /// </summary>
        public void SaveChanges()
        {
            _studentStudentCourseRepository.SaveChanges();
        }

    }
}
