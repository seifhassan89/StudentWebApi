namespace Models
{
    public class Gender
    {
        public int GenderID { get; set; }
        public string Name { get; set; }

        List<Course> Students { get; set; }
        public Gender()
        {
            Students = new List<Course>();
        }
    }
}