using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;

namespace Repositories
{
    public class GenderRepository : BaseRepository, IGenderRepository
    {
        private StudentDB _StudentDB;
        public GenderRepository(StudentDB studentDB) : base(studentDB)
        {
            _StudentDB = studentDB;
        }

        /// <summary>
        /// get all genders
        /// </summary>
        /// <returns></returns>
        public List<Gender> GetAll()
        {
            return _StudentDB.Genders.ToList();
        }

        /// <summary>
        /// get gender by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Gender? GetById(int id)
        {
            return _StudentDB.Genders.FirstOrDefault(g => g.GenderID == id);
        }
        /// <summary>
        /// delete gender
        /// </summary>
        /// <param name="gender"></param>
        public void DeleteGender(Gender gender)
        {
            _StudentDB.Remove(gender);
        }

        /// <summary>
        /// edit gender data
        /// </summary>
        /// <param name="genderId"></param>
        /// <param name="gender"></param>
        public bool EditGender(int genderId, Gender gender)
        {
            Gender? existingEntity = _StudentDB.Genders.Find(genderId);
            if (existingEntity == null)
            {
                return false;
            }
            else
            {
                _StudentDB.Entry(existingEntity).State = EntityState.Detached;
            }
            _StudentDB.Attach(gender);
            _StudentDB.Entry(gender).State = EntityState.Modified;
            return true;

        }

        /// <summary>
        /// add gender to database
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public Gender AddGender(Gender gender)
        {
            EntityEntry<Gender> x = _StudentDB.Genders.Add(gender);
            return x.Entity;

        }
    }
}
