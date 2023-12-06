using Event_System.Core.Entity.DTOs;
using Event_System.Persistance.Interface;
using Event_System.Persistance.Services;
using MediatR;

namespace Event_System.Application
{
    public class CancelTicketHandler : IRequestHandler<TicketDto ,string>
    {
        private readonly ITickcetRepository _ticketRepository;
        public CancelTicketHandler(ITickcetRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public async Task<string> Handle(TicketDto request, CancellationToken cancellationToken)
        {
            string s = _ticketRepository.CancelTicket(request.EventId, request.UserId);
            _ticketRepository.SaveChanges();
            return s;
        }
    }
}
