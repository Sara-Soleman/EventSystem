namespace Event_System.Core.Entity.Models
{
    public class Ticket : BaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; } = "";
        public int EventId { get; set; }
       
    }
}
