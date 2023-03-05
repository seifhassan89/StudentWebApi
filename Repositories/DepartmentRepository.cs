using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;

namespace Repositories
{
    public class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        private StudentDB _StudentDB;
        public DepartmentRepository(StudentDB studentDB) : base(studentDB)
        {
            _StudentDB = studentDB;
        }

        /// <summary>
        /// get all departments
        /// </summary>
        /// <returns></returns>
        public List<Department> GetAll()
        {
            return _StudentDB.Departments.ToList();
        }

        /// <summary>
        /// get department by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Department? GetById(int id)
        {
            return _StudentDB.Departments.FirstOrDefault(g => g.DepartmentID == id);
        }
        /// <summary>
        /// delete department
        /// </summary>
        /// <param name="department"></param>
        public void DeleteDepartment(Department department)
        {
            _StudentDB.Remove(department);
        }

        /// <summary>
        /// edit department data
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="department"></param>
        public bool EditDepartment(int departmentId, Department department)
        {
            Department? existingEntity = _StudentDB.Departments.Find(departmentId);
            if (existingEntity == null)
            {
                return false;
            }
            else
            {
                _StudentDB.Entry(existingEntity).State = EntityState.Detached;
            }
            _StudentDB.Attach(department);
            _StudentDB.Entry(department).State = EntityState.Modified;
            return true;
        }

        /// <summary>
        /// add department to database
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public Department AddDepartment(Department department)
        {
            EntityEntry<Department> x = _StudentDB.Departments.Add(department);
            return x.Entity;

        }
    }
}
