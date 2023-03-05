using Mappers;
using Models;
using Models.DTO;
using Repositories;

namespace Services
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IGenderMapper _genderMapper;
        public GenderService(IGenderRepository genderRepository, IGenderMapper genderMapper)
        {
            _genderRepository = genderRepository;
            _genderMapper = genderMapper;
        }

        /// <summary>
        /// get list of genders DTO
        /// </summary>
        /// <returns></returns>
        public List<GenderDTO> GetAll()
        {
            List<GenderDTO> genders = new List<GenderDTO>();
            genders = _genderRepository.GetAll().Select(g => _genderMapper.MapToGenderDTO(g)).ToList();
            return genders;
        }

        /// <summary>
        /// get genderDTO by gender Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GenderDTO? GetById(int id)
        {
            Gender? gender = _genderRepository.GetById(id);
            if (gender == null)
            {
                return null;
            }
            GenderDTO genderDTO = _genderMapper.MapToGenderDTO(gender);
            return genderDTO;
        }

        /// <summary>
        /// add gender to db
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public Gender AddGender(GenderDTO gender)
        {
            Gender genderEntity = _genderMapper.MapToGender(gender);
            return _genderRepository.AddGender(genderEntity);
        }

        /// <summary>
        /// delete gender 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteGender(int id)
        {
            Gender? gender = _genderRepository.GetById(id); ;
            if (gender == null)
            {
                return false;
            }
            _genderRepository.DeleteGender(gender);
            return true;

        }

        /// <summary>
        /// edit gender data 
        /// </summary>
        /// <param name="genderId"></param>
        /// <param name="genderDTO"></param>
        /// <returns></returns>
        public bool EditGender(int genderId, GenderDTO genderDTO)
        {
            Gender genderEntity = _genderMapper.MapToGender(genderDTO);
            return _genderRepository.EditGender(genderId, genderEntity);
        }

        /// <summary>
        /// save changes to DB
        /// </summary>
        public void SaveChanges()
        {
            _genderRepository.SaveChanges();
        }

    }
}
