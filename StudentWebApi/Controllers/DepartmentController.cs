using Mappers;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Services;

namespace StudentWebApi.Controllers
{
    [ApiController]
    [Route("Department")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IDepartmentMapper _departmentMapper;

        public DepartmentController(IDepartmentService departmentService, IDepartmentMapper departmentMapper)
        {
            _departmentService = departmentService;
            _departmentMapper = departmentMapper;
        }

        /// <summary>
        /// get department list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDepartments()
        {
            List<DepartmentDTO> result = _departmentService.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// get department by id
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        [HttpGet("{departmentId}")]
        public ActionResult GetDepartmentById([FromRoute] int departmentId)
        {
            DepartmentDTO? department = _departmentService.GetById(departmentId);
            return department == null ? NotFound() : Ok(department);
        }

        /// <summary>to Db
        /// add department 
        /// </summary>
        /// <param name="departmentDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddDepartment([FromBody] DepartmentDTO departmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please Add Department");
            }
            else
            {
                try
                {
                    Department AddDepartment = _departmentService.AddDepartment(departmentDTO);
                    _departmentService.SaveChanges();
                    DepartmentDTO departmentDTOResult = _departmentMapper.MapToDepartmentDTO(AddDepartment);
                    return Ok(departmentDTOResult);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        }

        /// <summary>
        /// edit department data in db
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="departmentDTO"></param>
        /// <returns></returns>
        [HttpPut("{departmentId}")]
        public ActionResult EditDepartment([FromRoute] int departmentId, [FromBody] DepartmentDTO departmentDTO)
        {

            bool isEdited = _departmentService.EditDepartment(departmentId, departmentDTO);
            if (!isEdited)
            {
                return NotFound("Department Not Found!!!!!!");
            }

            _departmentService.SaveChanges();
            return Ok(departmentDTO);
        }

        /// <summary>
        /// delete department from db
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>

        [HttpDelete("{departmentId}")]
        public ActionResult DeleteDepartment([FromRoute] int departmentId)
        {
            bool isDeleted = _departmentService.DeleteDepartment(departmentId);
            if (!isDeleted)
            {
                return NotFound("Department Not Found!!!!!!");
            }
            _departmentService.SaveChanges();
            return Ok("Department Deleted Successfully");
        }
    }
}
