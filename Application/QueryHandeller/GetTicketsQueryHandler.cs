using Event_System.Core.Entity.DTOs;
using Event_System.Core.Entity.Models;
using Event_System.Persistance.Interface;
using Event_System.Persistance.Services;
using MediatR;

namespace Event_System.Application.QueryHandeller
{
    public class GetTicketsQueryHandler : IRequestHandler<getTicketDto, List<Ticket>>
    {
        private readonly ITickcetRepository _ticketRepository;

        public GetTicketsQueryHandler(ITickcetRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<List<Ticket>> Handle(getTicketDto request, CancellationToken cancellationToken)
        {
            return _ticketRepository.GetAllTicket(request.UserId);
        }
    }
}
