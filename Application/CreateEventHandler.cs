using Event_System.Core.Entity.DTOs;
using Event_System.Core.Entity.Models;
using Event_System.Persistance.Interface;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Event_System.Application
{
    public class CreateEventHandler : IRequestHandler<EventDto1 , string>
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<string> Handle(EventDto1 request , CancellationToken cancellationToken)
        {
            var newEvent = new Event
            {
                EventName = request.eventDto.Name,
                Description = request.eventDto.Description,
                Location = request.eventDto.Location,
                DateTime = request.eventDto.DateTime,
                AvailableTickets = request.eventDto.AvailableTickets,
                UserId = request.userId,
                createdAt = DateTime.UtcNow
            };

            string s = _eventRepository.Add(newEvent);
            _eventRepository.SaveChanges();
            return s;
        }
    }
}
