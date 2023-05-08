namespace Capstone.Models
{
    public class Admin
    {
        public int Id { get; set; }
        //public string UserId { get; set; }
        public int DivisionId { get; set; }
        public Division Division { get; set; }
        public int Tenure { get; set; }
    }
}
