using Models;
using Models.DTO;

namespace Mappers
{
    public interface IGenderMapper
    {
        public Gender MapToGender(GenderDTO genderDTO);
        public GenderDTO MapToGenderDTO(Gender gender);

    }
}