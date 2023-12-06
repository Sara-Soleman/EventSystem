using Event_System.Core.Entity.DTOs;
using Event_System.Core.Entity.Models;
using Event_System.Core.Entity.UserModel;
using Event_System.Persistance.Interface;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Event_System.Application
{
    public class UpdateEventHandler : IRequestHandler<EventUpdate, string>
    {
        private readonly IEventRepository _eventRepository;
        public UpdateEventHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<string> Handle(EventUpdate request, CancellationToken cancellationToken)
        {
           string s = _eventRepository.Update(request);
            _eventRepository.SaveChanges();
            return s;
        }
    }
}
