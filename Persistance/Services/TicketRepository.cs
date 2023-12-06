using Event_System.Controllers;
using Event_System.Core.Entity.DTOs;
using Event_System.Core.Entity.Models;
using Event_System.Persistance.DataContext;
using Event_System.Persistance.Interface;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Event_System.Persistance.Services
{
    public class TicketRepository : ITickcetRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<TicketRepository> _logger;

        public TicketRepository(ApplicationDbContext dbContext , ILogger<TicketRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public string BookTicket(int EventId, string userId)
        {
            _logger.LogInformation("--------- ------------  " + EventId + "  " + userId);
            var Event = _dbContext.Events.FirstOrDefault(x => x.Id == EventId);

            if (Event != null)
            {
                _logger.LogInformation("---------  NOT NULL " + Event.EventName);
                int allTickcets = Event.AvailableTickets;
                _logger.LogInformation("---------  allTickcets  " + allTickcets);

                int bookedTickets = _dbContext.tickets.Where(x => x.EventId == EventId).Count();
                _logger.LogInformation("---------  bookedTickets " + bookedTickets);

                if (allTickcets > bookedTickets)
                {
                    Ticket t = new Ticket();
                    t.UserId = userId;
                    t.EventId = EventId;
                    _dbContext.tickets.Add(t);
                    return "Your ticket Booked";
                }
                else
                    return "No ticket Left";

            }
            else
                return "There is no Event";
        }

        public string CancelTicket(int EventId, string userId)
        {
            var Event = _dbContext.Events.FirstOrDefault(x => x.Id == EventId);

            if (Event != null)
            {
               
                Ticket bookedTickets = _dbContext.tickets.FirstOrDefault(x => x.EventId == EventId)!;
                if(bookedTickets != null)
                _dbContext.tickets.Remove(bookedTickets);
                return "Your Ticket Canceled";
            }
            return "There is no Event";
        }
        public List<Ticket> GetAllTicket(string userId)
        {
            return _dbContext.tickets.Where(x => x.UserId == userId).ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
