namespace Capstone.Models
{
    public class School
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int DivisionId { get; set; }
        public Division Division { get; set; }
    }
}
