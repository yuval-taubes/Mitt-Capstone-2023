using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Room { get; set; }

        public int? CourseId { get; set; }
        public virtual Course Course { get; set; }

        [ForeignKey("CapstoneUser")]
        public string? TeacherId { get; set; }
        public virtual CapstoneUser Teacher { get; set; }
    }
}
