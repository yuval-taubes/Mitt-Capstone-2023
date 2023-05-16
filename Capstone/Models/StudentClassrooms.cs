using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone.Models
{
    public class StudentClassrooms
    {
        public int Id { get; set; }

        [ForeignKey("CapstoneUser")]
        public string StudentId { get; set; }
        public virtual CapstoneUser? Student { get; set; }

        [ForeignKey("Classroom")]
        public int ClassroomId { get; set; }
        public virtual Classroom? Classroom { get; set; }

        
    }
}
