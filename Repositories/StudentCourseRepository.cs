using Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;

namespace Repositories
{
    public class StudentCourseRepository : BaseRepository, IStudentCourseRepository
    {
        private StudentDB _StudentDB;
        public StudentCourseRepository(StudentDB studentDB) : base(studentDB)
        {
            _StudentDB = studentDB;
        }

        /// <summary>
        /// get StudentCourse by course id and student id
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public StudentCourse? GetStudentCourse(int studentId, int courseId)
        {
            return _StudentDB.StudentCourses.FirstOrDefault(x => x.StudentID == studentId && x.CourseID == courseId);
        }


        /// <summary>
        /// delete studentCourse
        /// </summary>
        /// <param name="studentCourse"></param>
        public void DeleteStudentCourse(StudentCourse studentCourse)
        {
            _StudentDB.Remove(studentCourse);
        }


        /// <summary>
        /// add studentCourse to database
        /// </summary>
        /// <param name="studentCourse"></param>
        /// <returns></returns>
        public StudentCourse AddStudentCourse(StudentCourse studentCourse)
        {
            EntityEntry<StudentCourse> x = _StudentDB.StudentCourses.Add(studentCourse);
            return x.Entity;

        }
    }
}
