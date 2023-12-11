using Event_System.Core.Entity.DTOs;
using Event_System.Core.Entity.Models;
using Event_System.Persistance.DataContext;
using Event_System.Persistance.Interface;

namespace Event_System.Persistance.Services
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EventRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string Add(Event entity)
        {
            try
            {
                _dbContext.Events.Add(entity);
                return "TheEventCreated";
            }catch (Exception ex)
            {
                return "TheEventWasNotCreated";
            }
           
        }

        public string Delete(int Id, string userId)
        {
            var existingEvent = _dbContext.Events.FirstOrDefault(e => e.Id == Id);
            if (existingEvent != null)
            {
                if (existingEvent.UserId == userId)
                {
                    existingEvent.deletedAt = DateTime.Now;
                    existingEvent.isDeleted = true;
                    return "The Event Deleted";
                }
                return "You Are Not the Created User";
            }
            return "There is no Event Like that";
        }

        public List<Event> GetAll()
        {
            return _dbContext.Events.Where(x => x.isDeleted == false ).ToList(); ;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public string Update(EventUpdate eventUpdate)
        {
            var existingEvent = _dbContext.Events.FirstOrDefault(e => e.Id == eventUpdate.eventId);
            if (existingEvent != null)
            {
                if (existingEvent.UserId == eventUpdate.userId && existingEvent.isDeleted == false)
                {
                    existingEvent.EventName = eventUpdate.eventDto.Name;
                    existingEvent.Description = eventUpdate.eventDto.Description;
                    existingEvent.Location = eventUpdate.eventDto.Location;
                    existingEvent.DateTime = eventUpdate.eventDto.DateTime;
                    existingEvent.AvailableTickets = eventUpdate.eventDto.AvailableTickets;
                    existingEvent.updatedAt = DateTime.Now;
                    existingEvent.UserId = eventUpdate.userId;
                    existingEvent.createdAt = eventUpdate.eventDto.DateTime;

                    return "The Event Updated";
                }
                return "You Are Not the Created User";

            }
            return "There Is No Event Like That";
        }

       
    }
}
