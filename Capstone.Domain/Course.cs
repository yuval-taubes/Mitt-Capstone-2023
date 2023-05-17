namespace Capstone.Domain
{
    public class Course
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int SchoolId { get; set; }
        public virtual School School { get; set; }
    }
}
