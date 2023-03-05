using Mappers;
using Models;
using Models.DTO;
using Repositories;

namespace Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDepartmentMapper _departmentMapper;
        public DepartmentService(IDepartmentRepository departmentRepository, IDepartmentMapper departmentMapper)
        {
            _departmentRepository = departmentRepository;
            _departmentMapper = departmentMapper;
        }

        /// <summary>
        /// get list of departments DTO
        /// </summary>
        /// <returns></returns>
        public List<DepartmentDTO> GetAll()
        {
            List<DepartmentDTO> departments = new List<DepartmentDTO>();
            departments = _departmentRepository.GetAll().Select(g => _departmentMapper.MapToDepartmentDTO(g)).ToList();
            return departments;
        }

        /// <summary>
        /// get departmentDTO by department Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DepartmentDTO? GetById(int id)
        {
            Department? department = _departmentRepository.GetById(id);
            if (department == null)
            {
                return null;
            }
            DepartmentDTO departmentDTO = _departmentMapper.MapToDepartmentDTO(department);
            return departmentDTO;
        }

        /// <summary>
        /// add department to db
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public Department AddDepartment(DepartmentDTO department)
        {
            Department departmentEntity = _departmentMapper.MapToDepartment(department);
            return _departmentRepository.AddDepartment(departmentEntity);
        }

        /// <summary>
        /// delete department 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteDepartment(int id)
        {
            Department? department = _departmentRepository.GetById(id); ;
            if (department == null)
            {
                return false;
            }
            _departmentRepository.DeleteDepartment(department);
            return true;

        }

        /// <summary>
        /// edit department data 
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="departmentDTO"></param>
        /// <returns></returns>
        public bool EditDepartment(int departmentId, DepartmentDTO departmentDTO)
        {
            Department departmentEntity = _departmentMapper.MapToDepartment(departmentDTO);
            return _departmentRepository.EditDepartment(departmentId, departmentEntity);
        }

        /// <summary>
        /// save changes to DB
        /// </summary>
        public void SaveChanges()
        {
            _departmentRepository.SaveChanges();
        }

    }
}
