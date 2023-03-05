using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;

namespace Repositories
{
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        private StudentDB _StudentDB;
        public StudentRepository(StudentDB studentDB) : base(studentDB)
        {
            _StudentDB = studentDB;
        }

        /// <summary>
        /// get all students
        /// </summary>
        /// <returns></returns>
        public List<Student> GetAll()
        {
            return _StudentDB.Students.ToList();
        }

        /// <summary>
        /// get student by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student? GetById(int id)
        {
            return _StudentDB.Students.FirstOrDefault(g => g.StudentID == id);
        }
        /// <summary>
        /// delete student
        /// </summary>
        /// <param name="student"></param>
        public void DeleteStudent(Student student)
        {
            _StudentDB.Remove(student);
        }

        /// <summary>
        /// edit student data
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="student"></param>
        public bool EditStudent(int studentId, Student student)
        {
            Student? existingEntity = _StudentDB.Students.Find(studentId);
            if (existingEntity == null)
            {
                return false;
            }
            else
            {
                _StudentDB.Entry(existingEntity).State = EntityState.Detached;
            }
            _StudentDB.Attach(student);
            _StudentDB.Entry(student).State = EntityState.Modified;
            return true;
        }

        /// <summary>
        /// add student to database
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student AddStudent(Student student)
        {
            EntityEntry<Student> x = _StudentDB.Students.Add(student);
            return x.Entity;

        }

        /// <summary>
        ///  get student courses by student ID 
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public List<Course> GetCoursesByStudentId(int studentId)
        {
            List<Course> courses = new List<Course>();
            Student? student = _StudentDB.Students
                .Include(x => x.StudentCourses)
                .ThenInclude(x => x.Course).FirstOrDefault(x => x.StudentID == studentId);
            if (student != null)
            {
                courses = student.StudentCourses.Select(x => x.Course).ToList();
            }
            return courses;
        }
    }
}
