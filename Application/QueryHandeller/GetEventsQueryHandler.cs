using Event_System.Core.Entity.DTOs;
using Event_System.Core.Entity.Models;
using Event_System.Persistance.Interface;
using MediatR;

namespace Event_System.Application.QueryHandeller
{
    public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery,List<Event>>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventsQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<List<Event>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            return _eventRepository.GetAll();
        }
    }
}
