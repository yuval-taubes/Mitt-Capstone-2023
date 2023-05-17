namespace Capstone.Domain
{
    public class School
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int DivisionId { get; set; }
        public virtual Division Division { get; set; }
    }
}
