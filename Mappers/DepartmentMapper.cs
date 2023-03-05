using Models;
using Models.DTO;

namespace Mappers
{
    public class DepartmentMapper : IDepartmentMapper
    {
        /// <summary>
        /// map DepartmentDTO to Department
        /// </summary>
        /// <param name="departmentDTO"></param>
        /// <returns></returns>
        public Department MapToDepartment(DepartmentDTO departmentDTO)
        {
            Department department = new Department();
            department.DepartmentID = departmentDTO.DepartmentID;
            department.Name = departmentDTO.Name;
            return department;

        }

        /// <summary>
        /// map Department to DepartmentDTO
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public DepartmentDTO MapToDepartmentDTO(Department department)
        {
            DepartmentDTO departmentDTO = new DepartmentDTO();
            departmentDTO.DepartmentID = department.DepartmentID;
            departmentDTO.Name = department.Name;
            return departmentDTO;

        }
    }
}