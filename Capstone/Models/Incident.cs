namespace Capstone.Models
{
    public class Incident
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public int StudentClassroomId { get; set; }
        public virtual StudentClassrooms? StudentClassrooms { get; set; }

        public string Message { get; set; }
    }
}
