using MediatR;

namespace Event_System.Core.Entity.DTOs
{
    public class EventDto : IRequest<string>
    {
        
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Location { get; set; } = "";
        public DateTime DateTime { get; set; }
        public int AvailableTickets { get; set; }
        public bool isDeleted { get; set; } = false;

    }
    public class EventDto1 : IRequest<string>
    {
        public EventDto1(string id, EventDto _eventDto)
        {
            userId = id;
            eventDto = _eventDto;
        }
        public string userId { get; set; } = "";
        public EventDto eventDto { get; set; } 
       

    }
    public class EventUpdate : IRequest<string>
    {
        public EventUpdate(string id, int _eventId, EventDto eventDto)
        {
            userId = id;
            eventId = _eventId;
            this.eventDto = eventDto;
        }
        public string userId { get; set; } = "";
        public int eventId { get; set; }
        public EventDto eventDto { get; set; }

    }
    public class EventDelete : IRequest<string>
    {
        public EventDelete(string id, int _eventId)
        {
            userId = id;
            eventId = _eventId;
           
        }
        public string userId { get; set; } = "";
        public int eventId { get; set; }
       

    }

}
