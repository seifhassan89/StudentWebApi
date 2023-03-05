namespace Data
{
    public abstract class BaseRepository : IBaseRepository
    {
        private readonly StudentDB _employeeDb;
        public BaseRepository(StudentDB studentDB)
        {
            _employeeDb = studentDB;
        }

        public void SaveChanges()
        {
            _employeeDb.SaveChanges();
        }
    }
}
