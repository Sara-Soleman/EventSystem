using Event_System.Core.Entity.Models;
using MediatR;

namespace Event_System.Core.Entity.DTOs
{
    public class TicketDto :  IRequest<string>
    {
        public TicketDto(string id , int Eid)
        {
            UserId = id;
            EventId = Eid;
        }
        public int EventId { get; set; }
        public string UserId { get; set; } = "";
    }
    public class TicketDto1 :  IRequest<string>
    {
        public TicketDto1(string id , int Eid)
        {
            UserId = id;
            EventId = Eid;
        }
        public int EventId { get; set; }
        public string UserId { get; set; } = "";
    }
    public class getTicketDto : IRequest<List<Ticket>>
    {
        public getTicketDto(string id)
        {
            UserId = id;
        }
        public string UserId { get; set; } = "";
    }
}
