using Mappers;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Services;

namespace StudentWebApi.Controllers
{
    [ApiController]
    [Route("Gender")]
    public class GenderController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IGenderMapper _genderMapper;

        public GenderController(IGenderService genderService, IGenderMapper genderMapper)
        {
            _genderService = genderService;
            _genderMapper = genderMapper;
        }

        /// <summary>
        /// get gender list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetGenders()
        {
            List<GenderDTO> result = _genderService.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// get gender by id
        /// </summary>
        /// <param name="genderId"></param>
        /// <returns></returns>
        [HttpGet("{genderId}")]
        public ActionResult GetGenderById([FromRoute] int genderId)
        {
            GenderDTO? gender = _genderService.GetById(genderId);
            return gender == null ? NotFound() : Ok(gender);
        }

        /// <summary>to Db
        /// add gender 
        /// </summary>
        /// <param name="genderDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddGender([FromBody] GenderDTO genderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please Add Gender");
            }
            else
            {
                try
                {
                    Gender AddGender = _genderService.AddGender(genderDTO);
                    _genderService.SaveChanges();
                    GenderDTO genderDTOResult = _genderMapper.MapToGenderDTO(AddGender);
                    return Ok(genderDTOResult);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        }

        /// <summary>
        /// edit gender data in db
        /// </summary>
        /// <param name="genderId"></param>
        /// <param name="genderDTO"></param>
        /// <returns></returns>
        [HttpPut("{genderId}")]
        public ActionResult EditGender([FromRoute] int genderId, [FromBody] GenderDTO genderDTO)
        {

            bool isEdited = _genderService.EditGender(genderId, genderDTO);
            if (!isEdited)
            {
                return NotFound("Gender Not Found!!!!!!");
            }

            _genderService.SaveChanges();
            return Ok(genderDTO);
        }

        /// <summary>
        /// delete gender from db
        /// </summary>
        /// <param name="genderId"></param>
        /// <returns></returns>

        [HttpDelete("{genderId}")]
        public ActionResult DeleteGender([FromRoute] int genderId)
        {
            bool isDeleted = _genderService.DeleteGender(genderId);
            if (!isDeleted)
            {
                return NotFound("Gender Not Found!!!!!!");
            }
            _genderService.SaveChanges();
            return Ok("Gender Deleted Successfully");
        }
    }
}
