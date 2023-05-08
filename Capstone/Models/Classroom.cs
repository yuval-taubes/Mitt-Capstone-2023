namespace Capstone.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Room { get; set; }

        public int? CourseId { get; set; }
        public Course Course { get; set; }

        public string? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
