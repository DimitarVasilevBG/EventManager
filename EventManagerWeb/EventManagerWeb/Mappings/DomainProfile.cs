using AutoMapper;
using EventManager.Database.DbModels;
using EventManager.Models.Models;
using EventManager.Models.ViewModels;
namespace EventManagerWeb.Mappings
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<EventDbModel, CreateViewModel>();
            CreateMap<Event, EventDbModel>();
        }
    }
}
