using Event_System.Core.Entity.DTOs;
using Event_System.Persistance.Interface;
using MediatR;

namespace Event_System.Application
{
    public class DeleteEventHandler : IRequestHandler<EventDelete, string>
    {
        private readonly IEventRepository _eventRepository;
        public DeleteEventHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<string> Handle(EventDelete request, CancellationToken cancellationToken)
        {
            string s =_eventRepository.Delete(request.eventId , request.userId);
            _eventRepository.SaveChanges();
            return s;
        }
    }
}
