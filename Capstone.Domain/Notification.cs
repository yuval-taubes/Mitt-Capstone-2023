namespace Capstone.Domain
{
    public class Notification
    {
        public int? Id { get; set; }
        public DateTime Sent { get; set; }
        public DateTime Read { get; set; }

        public int IncidentId { get; set; }
        public virtual Incident Incident { get; set; }
    }
}
