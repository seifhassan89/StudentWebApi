using Models;
using Models.DTO;

namespace Mappers
{
    public class GenderMapper : IGenderMapper
    {
        /// <summary>
        /// map GenderDTO to Gender
        /// </summary>
        /// <param name="genderDTO"></param>
        /// <returns></returns>
        public Gender MapToGender(GenderDTO genderDTO)
        {
            Gender gender = new Gender();
            gender.GenderID = genderDTO.GenderID;
            gender.Name = genderDTO.Name;
            return gender;

        }

        /// <summary>
        /// map Gender to GenderDTO
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public GenderDTO MapToGenderDTO(Gender gender)
        {
            GenderDTO genderDTO = new GenderDTO();
            genderDTO.GenderID = gender.GenderID;
            genderDTO.Name = gender.Name;
            return genderDTO;

        }
    }
}