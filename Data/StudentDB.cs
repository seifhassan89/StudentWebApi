using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class StudentDB : DbContext
    {
        public StudentDB(DbContextOptions<StudentDB> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Gender> Genders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Gender> genders = new List<Gender>();
            genders.Add(new Gender
            {
                GenderID = 1,
                Name = "Male"
            });
            genders.Add(new Gender
            {
                GenderID = 2,
                Name = "Female"
            });
            modelBuilder.Entity<Gender>().HasData(genders);


        }
    }
}
