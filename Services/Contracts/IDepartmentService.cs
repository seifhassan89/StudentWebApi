using Models;
using Models.DTO;

namespace Services
{
    public interface IDepartmentService
    {
        public List<DepartmentDTO> GetAll();
        public DepartmentDTO? GetById(int id);
        public bool EditDepartment(int departmentId, DepartmentDTO departmentDTO);
        public bool DeleteDepartment(int id);
        public Department AddDepartment(DepartmentDTO department);
        public void SaveChanges();

    }
}
