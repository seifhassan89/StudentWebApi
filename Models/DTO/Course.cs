namespace Models.DTO
{
    public class CourseDTO
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
        public string? DepartmentName { get; set; }

        public CourseDTO()
        {
        }
    }
}