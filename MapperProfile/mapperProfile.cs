using AutoMapper;
using Event_System.Core.Entity.DTOs;
using Event_System.Core.Entity.Models;
using Event_System.Core.Entity.UserModel;

namespace Event_System.MapperProfile
{
    public class mapperProfile : Profile
    {
        public mapperProfile()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Event, EventDto>().ReverseMap();
            });
            CreateMap<Event, EventDto>().ReverseMap();
        }
        
    }
}
