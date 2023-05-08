namespace Capstone.Models
{
    public class Course
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}
