using Event_System.Core.Entity.DTOs;
using Event_System.Persistance.Interface;
using MediatR;

namespace Event_System.Application
{
    public class BookTicketHandler : IRequestHandler<TicketDto1, string>
    {
        private readonly ITickcetRepository _ticketRepository;
        public BookTicketHandler(ITickcetRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public async Task<string> Handle(TicketDto1 request, CancellationToken cancellationToken)
        {
            string s = _ticketRepository.BookTicket(request.EventId, request.UserId);
            _ticketRepository.SaveChanges();
            return s;
        }
    }
}
