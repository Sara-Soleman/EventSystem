using Event_System.Core.Entity.Models;

namespace Event_System.Persistance.Interface
{
    public interface ITickcetRepository 
    {
        public string BookTicket(int EventId, String userId);
        public string CancelTicket(int EventId, String userId);
        public List<Ticket> GetAllTicket( String userId);
        void SaveChanges();

    }
}
