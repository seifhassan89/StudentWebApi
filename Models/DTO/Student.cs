namespace Models.DTO
{
    public class StudentDTO
    {
        public int StudentID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int GenderID { get; set; }
        public String? GenderName { get; set; }

        public StudentDTO()
        {
        }
    }
}