namespace Capstone.Models
{
    public class StudentClassrooms
    {
        public int? Id { get; set; }

        public string StudentId { get; set; }
        public Student Student { get; set; }

        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
    }
}
