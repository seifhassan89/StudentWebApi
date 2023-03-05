using Data;
using Models;

namespace Repositories
{
    public interface IDepartmentRepository : IBaseRepository
    {
        public List<Department> GetAll();
        public Department? GetById(int id);

        public Department AddDepartment(Department department);
        bool EditDepartment(int departmentId, Department department);
        public void DeleteDepartment(Department department);
    }
}
