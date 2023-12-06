using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Event_System.Core.Entity
{
    public class BaseEntity
    {
        public long Id { set; get; }

        public string TimestampId { set; get; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime deletedAt { get; set; }
        protected BaseEntity()
        {
            TimestampId = DateTime.Now.ToString();
        }
    }
}
