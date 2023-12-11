using Event_System.Core.Entity.Models;
using MediatR;

namespace Event_System.Core.Entity.DTOs
{
    public class GetEventsQuery : IRequest<List<Event>>
    {
    }
}
