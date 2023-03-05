using Models;
using Models.DTO;

namespace Mappers
{
    public interface IDepartmentMapper
    {
        public Department MapToDepartment(DepartmentDTO departmentDTO);
        public DepartmentDTO MapToDepartmentDTO(Department department);

    }
}