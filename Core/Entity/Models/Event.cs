using Event_System.Core.Entity.UserModel;

namespace Event_System.Core.Entity.Models
{
    public class Event : BaseEntity
    {
       
        public string EventName { get; set; } = "";
        public string Description { get; set; } = "";
        public string Location { get; set; } = "";
        public DateTime DateTime { get; set; }
        public int AvailableTickets { get; set; }
        public bool isDeleted { get; set; } = false;
        public User user { get; set; } 
        public string UserId { get; set; }

    }
}
