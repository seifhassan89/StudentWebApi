using Models;
using Models.DTO;

namespace Services
{
    public interface IGenderService
    {
        public List<GenderDTO> GetAll();
        public GenderDTO? GetById(int id);
        public bool EditGender(int genderId, GenderDTO genderDTO);
        public bool DeleteGender(int id);
        public Gender AddGender(GenderDTO gender);
        public void SaveChanges();

    }
}
